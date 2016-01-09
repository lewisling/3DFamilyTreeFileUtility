using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Security.Authentication;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FamilySearch.Api;
using FamilySearch.Api.Ft;
using FamilySearch.Api.Util;
using Gx.Conclusion;
using Gx.Rs.Api;
using Gx.Rs.Api.Options;
using Gx.Rs.Api.Util;
using UnityTreeScripts;

namespace _3DFamilyTreeForms
{
    public class FamilyHistorySource
    {
        public SourceType type = SourceType.Null;
        public string description = "";
        public string username = "";
        public string password = "";
        public string developerKey = "";
        public bool isFamilySearch = false;
        public bool isSandBox = false;
        public bool isDescendancy = false;
        public bool isAncestry = false;
        public bool isBoth = false;
        public string startingID = "SELF";
        public int numberOfGenerations = 4;
        public int adamEveStartYear = 0;
        public int adamEveEndYear = 80;

        public string fileName = ""; // used for file read and save
        public bool isReadFromFile = false;
        public bool isSaveToFile = false;

        public FamilySearchFamilyTree ft = null;

        private CourtHouse _courtHouse;
        private BackgroundWorker _worker;

        public FamilyHistorySource(SourceType sourceType)
        {
            type = sourceType;

            string familySearchConfigFile = ConfigurationManager.AppSettings["FamilySearchConfigFile"];
            var configFileReader = new CustomConfigurationFileReader(familySearchConfigFile);
            var config = configFileReader.Config;

            switch (type)
            {                    
                case SourceType.FamilySearchService:
                    description = "Family Search - Descendancy";
                    isFamilySearch = true;
                    isDescendancy = true;
                    isAncestry = false;
                    isBoth = false;

                    isSandBox = config.AppSettings.Settings["isSandBox"].Value.ToLower().Contains("true");
                    username = config.AppSettings.Settings["username"].Value;
                    password = config.AppSettings.Settings["password"].Value;
                    developerKey = config.AppSettings.Settings["developerKey"].Value;
                    startingID = config.AppSettings.Settings["startingID"].Value;

                    break;
                case SourceType.RandomAdamEvePopulation:
                    description = "Adam and Eve Random Population Generator - Descendancy";                    
                    isDescendancy = true;
                    isAncestry = false;
                    isBoth = false;
                    break;
                case SourceType.ReadFromFile:
                    break;

            }

        }

        public bool initializeConnection()
        {
            if (isFamilySearch)
            {
                #region Comments galore regarding the GEDCOMX and FamilySearch API
                /* * * * * * * *
                FamilySearch C# SDK info:
                https://familysearch.org/developers/libraries/csharp
                https://www.nuget.org/packages/FamilySearch.API.SDK/
                https://github.com/FamilySearch/gedcomx-csharp
                https://github.com/FamilySearch/gedcomx/tree/master/specifications

                //Documentation
                //https://github.com/FamilySearch/gedcomx/blob/master/specifications/conceptual-model-specification.md

                URL: https://sandbox.familysearch.org 

                Usefull online utility to copy a tree from production to the sandbox
                http://familysearch.github.io/sandbox-data-copy/

                * * * * * * */
                #endregion

                if (ft == null)
                    ft = new FamilySearchFamilyTree(isSandBox); // true means sandbox reference. 
          
                Form signInForm = new SignInFormWizard(this, ft, username, password, developerKey);
   
                var dialogRet = signInForm.ShowDialog();

                if (dialogRet == DialogResult.Cancel)
                {
                    return false;
                }

                if (!ft.IsAuthenticated)
                    throw new Exception("Authentication to FamilySearch Failed");

                return true;
            }

            throw new NotImplementedException("This connection type NOT IMPLEMENTED YET");
        }


        public bool readCollection(CourtHouse courtHouse, BackgroundWorker worker)
        {

            _courtHouse = courtHouse;
            _worker = worker;

            // Given Ascestory Descendancy Both
            // # Generations (Radius)
            // Starting ID
            // Add persons family as parent (Person)
            // enumerate children (Person)
            // enumerate parents (person)
            // Write:
            // Recursive Add Descendants (person, generations)
            // Recursive Add Ancestors (Person, Generations)
            //  We need to be able to run both, so worry about overlap


            if (_worker.CancellationPending == true) return false;

            if (startingID.ToLower() == "self")
            {
                UserState userState = ft.ReadCurrentUser();
                startingID = userState.Id;
            }
            
            FamilyTreePersonState personState = ft.ReadPersonById(startingID);

            if (_worker.CancellationPending == true) return false;

            // this does a descendancy recursion
            if (!AddPersonsFamily(personState, numberOfGenerations)) return false;

            return true;
        }

        /// <summary>
        /// Add this person as a parent to their own family
        /// as well a Generation-1 other descendants
        /// Assumes this is a Descendancy type of flow
        /// </summary>
        /// <param name="personState">The Family Search Person to act on</param>
        /// <param name="generation">The Generation Radius that is left over.  When 1, only return Spouse if exists, decrement to Zero and return
        /// Otherwise if Generation Radius is more than Zero after decrement, then call This function recursivley on all children found.</param>
        public bool AddPersonsFamily(PersonState personState, int generation = 1)
        {

            var person = personState.Person;

            TreePerson treePerson = new TreePerson(TreePerson.PersonType.FamilySearch, person.Id, person);
            var treePersonIndex = _courtHouse.myPeople.addToAllPeople(treePerson);

            //Rec function assumes that the person is already added to the CourtHouse

            return RecAddPersonsFamily(personState, treePersonIndex, generation);


        }
        private bool RecAddPersonsFamily(PersonState personState, int treePersonIndex, int generation = 1)
        {
            //Person must already be added to CourtHouse

            DescendancyResultsState descendacyState = personState.ReadDescendancy(
                FamilySearchOptions.IncludePersonDetails(),
                FamilySearchOptions.IncludeMarriageDetails(),
                FamilySearchOptions.IncludePersons(),
                QueryParameter.Generations(2)
                );

            if (_worker.CancellationPending == true) return false;

            //DescendancyResultsState
            DescendancyTree.DescendancyNode myNode = descendacyState.Tree.Root;

            TreePerson treePersonSpouce = new TreePerson(TreePerson.PersonType.Null);

            if (myNode.Spouse != null)
            {
                treePersonSpouce = new TreePerson(TreePerson.PersonType.FamilySearch, myNode.Spouse.Id,
                    myNode.Spouse);
            }
            
            var treePersonSpouceIndex = _courtHouse.myPeople.addToAllPeople(treePersonSpouce);

            var familyIndex = _courtHouse.StartFamily(treePersonIndex, treePersonSpouceIndex,
                myNode.Person.DisplayExtension.MarriageDate);

            var nextGenerationValue = generation - 1;

            // Are we done with our recursion??

            if (nextGenerationValue == 0) return true;

            List<DescendancyTree.DescendancyNode> children = myNode.Children;

            if (children != null)
            {
                // Add all the children to the family
                foreach (var child in children)
                {
                    if (_worker.CancellationPending == true) return false;

                    var childPersonIndex =_courtHouse.AddChild(familyIndex, child.Person.Id, child.Person);

                    FamilyTreePersonState childPersonState = ft.ReadPersonById(child.Person.Id);

                    if (RecAddPersonsFamily(childPersonState, childPersonIndex, nextGenerationValue) == false)
                        return false;

                }

            }

            return true;
        }

        public enum SourceType
        {
            Null,
            FamilySearchService,
            RandomAdamEvePopulation,
            ReadFromFile
        }
    }
}

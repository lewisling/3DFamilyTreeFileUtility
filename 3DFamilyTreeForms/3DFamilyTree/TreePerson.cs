using System;
using System.Collections.Generic;
using System.Diagnostics;
using Gx.Conclusion;

namespace _3DFamilyTreeFileUtility
{
    public class TreePerson
    {
        private readonly Person _familSearchPerson = null;
        private readonly string _familySearchID = "";
        public string Name = "";
        public PersonSex Sex = PersonSex.NotSet;
        public string Birth = "";
        public string Death = "";
        public string Lifespan = "";
        public string PortraitURI = "";
        public List<FamilyEvent> myEvents;
        public int BirthFamilyIndex = 0;
        public int MarriedFamilyIndex = 0;

        /// <summary>
        ///  TODO
        /// Create an Events list
        /// Each Event (modeled after the current Marriage event)has:
        /// Name (Marriage, Divorce, Adoption)
        /// Date
        /// Generation
        /// BridePersonIndex, GroomPersonIndex, FamilyIndex
        /// 
        /// </summary>

        private string[] MaleNames = new string[] {"Adam", "Barney", "Charlie"};


        private string[] FemaleNames = new string[] {"Eve", "Beth", "Cindy"};

        public enum PersonType
        {
            Null,
            Unique,
            Adam,
            Eve,
            FamilySearch
        }

        public enum PersonSex
        {
            NotSet,
            Male,
            Female
        }

        public struct timeSpan
        {
            public int Start;
            public int End;
        }

        public TreePerson() : this(PersonType.Null, "", null) { }

        public TreePerson(PersonType Type, string idString = "", Person familySearchPerson = null)
        {
            switch (Type)
            {
                case PersonType.Null:
                    Name = Death = "";
                    Sex = PersonSex.NotSet;
                    Birth = idString;
                    break;

                case PersonType.Unique:
                    var perRandom = StaticRandom.RandomNumber(0, 100);
                    //Debug.WriteLine("Random " + perRandom);
                    if (perRandom > 49)
                    {
                        Sex = PersonSex.Male;
                        Name = MaleNames[StaticRandom.RandomNumber(0, MaleNames.Length)];
                        Birth = idString;
                    }
                    else
                    {
                        Sex = PersonSex.Female;
                        Name = FemaleNames[StaticRandom.RandomNumber(0, FemaleNames.Length)];
                        Birth = idString;
                    }
                    break;

                case PersonType.Adam:
                    Sex = PersonSex.Male;
                    Name = "Adam";
                    Birth = idString;
                    BirthFamilyIndex = 0; // from Generation 0
                    break;

                case PersonType.Eve:
                    Sex = PersonSex.Female;
                    Name = "Eve";
                    Birth = idString;
                    BirthFamilyIndex = 0; // from Generation 0
                    break;

                case PersonType.FamilySearch:
                    if (familySearchPerson != null)
                    {
                        _familSearchPerson = familySearchPerson;

                        // Just the basics of the person are set now
                        Name = familySearchPerson.DisplayExtension.Name;
                        Sex = GetSexEnum(familySearchPerson.DisplayExtension.Gender);                      
                        Birth = familySearchPerson.DisplayExtension.BirthDate ?? "";
                        Death = familySearchPerson.DisplayExtension.DeathDate ?? "";
                        Lifespan = familySearchPerson.DisplayExtension.Lifespan;
                        _familySearchID = familySearchPerson.Id;
                    }

                    break;
            }

            myEvents = new List<FamilyEvent>();
        }

        public void setBirthFamilyIndex(int index)
        {
            BirthFamilyIndex = index;
        }

        public void AddEvent(FamilyEvent newEvent)
        {

            myEvents.Add(newEvent);

        }

        public void setMarriedFamilyIndex(int index)
        {
            MarriedFamilyIndex = index;
        }

        public bool AskToMarry()
        {
            bool retAnswer = false;

            int iRand = StaticRandom.RandomNumber(0, 10);
            if (iRand > 2) retAnswer = true;
            //Debug.WriteLine(Name + " Got asked to Marry. iRand =" + iRand.ToString());
            //Debug.WriteLine("She said " + (retAnswer ? "Yes" : "No") + "!!!!!!!!!!!!!!!!!!!!!!!!!");
            return retAnswer;
        }

        public bool isDeathEvent(int mortalityRate, int currentYear) // Chance out of 100000
        {
            bool retAnswer = false;
            int iRand = StaticRandom.RandomNumber(1, 100000);
            if (iRand < mortalityRate)
            {
                retAnswer = true;
                //Debug.WriteLine(Name + " Just Died at age " + ageText(currentYear) + ", I am sorry. mortalityRate=" + mortalityRate + ", iRand =" + iRand.ToString());
            }
            return retAnswer;
        }

        public string GetSex()
        {
            string retSex = "NotSet";
            if (Sex == PersonSex.Male) retSex = "Male";
            if (Sex == PersonSex.Female) retSex = "Female";
            if (Sex == PersonSex.NotSet) retSex = "Not Set";


            return retSex;

        }
   
        public PersonSex GetSexEnum(string sexString)
        {
            var retSexEnum = PersonSex.NotSet;
            if (sexString != null)
            {
                if (sexString.ToLower().Contains("fe"))
                {
                    retSexEnum = PersonSex.Female;
                }
                else if (sexString.ToLower().Contains("male"))
                {
                    retSexEnum = PersonSex.Male;
                }
            }
            return retSexEnum;
        }

        public string ageText(int currentYear)
        {
            int ibirth;
            string age = "No Birth Year";
            if (int.TryParse(this.Birth, out ibirth))
            {
                age = (currentYear - ibirth).ToString();
            }
            return age;
        }

        public int age(int currentYear)
        {
            int ibirth;
            int age = 0;
            if (int.TryParse(this.Birth, out ibirth))
            {
                age = currentYear - ibirth;
            }
            return age;
        }

        public int birthDateInt()
        {
            int ibirth = 0;
            if (!int.TryParse(this.Birth, out ibirth))
            {
                ibirth = 0;
            }
            return ibirth;
        }

        public int deathDateInt()
        {
            int ideath = 0;
            if (!int.TryParse(this.Death, out ideath))
            {
                ideath = 0;
            }
            return ideath;
        }

        public bool isMarried()
        {
            bool retMarried = false;
            foreach (FamilyEvent chkEvent in myEvents)
            {
                if (chkEvent.EventType == FamilyEvent.FamilyEventType.Marriage)
                    retMarried = true;
            }
            return retMarried;
        }

        public int marriageDateInt()
        {
            int imarriage = 0;
            foreach (FamilyEvent chkEvent in myEvents)
            {
                if (chkEvent.EventType == FamilyEvent.FamilyEventType.Marriage)
                {
                    if (int.TryParse(chkEvent.Date, out imarriage)) break;
                }
            }
            return imarriage;
        }

        public int ageAtDeath()
        {
            int ibirth;
            int ideath;
            int retAgeAtDeath = 0;
            if (int.TryParse(this.Death, out ideath))
            {
                if (int.TryParse(this.Birth, out ibirth))
                {
                    retAgeAtDeath = ideath - ibirth;
                }
            }
            return retAgeAtDeath;
        }

        public bool isDead()
        {
            bool retDeath = false;
            if (this.Death != "")
                retDeath = true;
            return retDeath;
        }

        public bool isAlive()
        {
            bool retAlive = false;
            if (this.Death == "")
                retAlive = true;
            return retAlive;
        }

        public string GetText(int currentYear, int personIndex)
        {
            string age = this.ageText(currentYear);

            string retString = "Name=" + this.Name + "(" + personIndex + ") FS ID " + this._familySearchID + ", Sex=" + this.GetSex() + ", Birth=" +
                               this.Birth + ", " +
                               (this.Death == ""
                                   ? ("Living, Age=" + age)
                                   : ("Death=" + this.Death +
                                   (this.Lifespan == "" ? " age at death=" + ageAtDeath() : " Lifespan=" + this.Lifespan)
                                   )) + "\r\n";

       //     (this.Death == ""
       //? ("Living, Age=" + age)
       //: (this.Death + " age at death=" + ageAtDeath())) + "\r\n";
            foreach (FamilyEvent chkEvent in myEvents)
            {
                retString += chkEvent.GetText() + "\r\n";
            }
            return retString;
        }

    }

}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace _3DFamilyTreeFileUtility
{
    public class Matchmaker
    {
        public List<Family> allFamilies;
        public MyPeople myPeople = new MyPeople();

        public List<int> BachelorettePersonIndexList;
        public List<int> BachelorPersonIndexList;

        private static int _childBearingAge = 49;
        private static int _babySpacingYears = 2;
        private static int _firstChildAfterMarriage = 1;
        private static int _chanceForABaby = 30; //percent

        /// <summary>
        /// Matchmaker has all the powers of populating the earch. Refer to Genesis 1:28
        /// God Created Man and Woman.. God Said "Be Fruitful and multiply, and fill the Earth"
        /// Well... the Matchmaker class and Method simulates this. Starting at the constructor 
        /// where Family 0 is created "Adam abd Eve" of couse.
        /// Based on a pool (List) of available bachelors and bachelorettes, and a list current families
        /// These methods are meant to be called while moving a 'currentYear' counter forward year by year.
        /// Your can move through several hundred or several thousand years, and find your world populated.
        /// Some interesting parameters and probabilities are used to drive this creation.
        /// </summary>
        public Matchmaker()
        {
            
        }

        public void init()
        {
            BachelorPersonIndexList = new List<int>();
            BachelorettePersonIndexList = new List<int>();
            allFamilies = new List<Family>();
            myPeople.init();

            Family zeroFamily = new Family(0, 0, 0, "");
            addToAllFamilies(zeroFamily);
            // THis will serve as the root of the tree and Generation 0, Adam and Eve can be Generation 1
        }
        public void addToSinglesList(int newPersonIndex, TreePerson.PersonSex sex)
        {
            if (sex == TreePerson.PersonSex.Female)
                BachelorettePersonIndexList.Add(newPersonIndex);
            else
                BachelorPersonIndexList.Add(newPersonIndex);

        }

        public void removeFromSinglesList(int deadPersonIndex, TreePerson.PersonSex sex)
        {
            if (sex == TreePerson.PersonSex.Female)
                BachelorettePersonIndexList.Remove(deadPersonIndex);
            else
                BachelorPersonIndexList.Remove(deadPersonIndex);

        }

        public void doWeddings(int currentYear)
        {

            //foreach( int BoyPersonIndex in BachelorPersonIndexList) DOES NOT work because we modify the list see Remove below
            for (int i = 0; i < BachelorPersonIndexList.Count; i++)
            {
                FamilyEvent marriageevent = makeMatch(BachelorPersonIndexList[i], currentYear);
                if (marriageevent != null)
                {
                    Family myFamily = new Family(marriageevent.Generation, marriageevent.BridePersonIndex,
                        marriageevent.GroompersonIndex, marriageevent.Date);
                    int familyIndex = addToAllFamilies(myFamily);
                    marriageevent.FamilyIndex = familyIndex;
                    myPeople.allPeople[marriageevent.BridePersonIndex].MarriedFamilyIndex = familyIndex;
                    myPeople.allPeople[marriageevent.GroompersonIndex].MarriedFamilyIndex = familyIndex;
                    myPeople.allPeople[marriageevent.BridePersonIndex].AddEvent(marriageevent);
                    myPeople.allPeople[marriageevent.GroompersonIndex].AddEvent(marriageevent);

                }
            }
        }

        public FamilyEvent makeMatch(int BoyPersonIndex, int currentYear)
        {
            int ofAge = 18;

            FamilyEvent retMarriageEvent = null;

            int iage = myPeople.allPeople[BoyPersonIndex].age(currentYear);
            if (iage < ofAge) return retMarriageEvent;

            int GirlPersonIndex = findAWife(BoyPersonIndex, iage, currentYear);
            if (GirlPersonIndex != 0)
            {
                retMarriageEvent = new FamilyEvent(myPeople, allFamilies, FamilyEvent.FamilyEventType.Marriage, currentYear.ToString(),
                    GirlPersonIndex, BoyPersonIndex);

                BachelorettePersonIndexList.Remove(GirlPersonIndex);
                BachelorPersonIndexList.Remove(BoyPersonIndex);
            }
            return retMarriageEvent;
        }

        public int findAWife(int BoyPersonIndex, int primeAge, int currentYear)
        {
            int ofAge = 16;
            int reasonableDelta = 6;

            int retPersonIndex = 0;

            foreach (int GirlPersonIndex in BachelorettePersonIndexList)
            {
                if (myPeople.allPeople[GirlPersonIndex].isAlive())
                {
                    int iage = myPeople.allPeople[GirlPersonIndex].age(currentYear);
                    if ((iage >= ofAge) && (Math.Abs(primeAge - iage) <= reasonableDelta))
                    {

                        if (myPeople.allPeople[GirlPersonIndex].AskToMarry())
                        {
                            // Only if she says yes, otherwise you are out of luck this year
                            //retPerson = new Person(Person.PersonType.Null);
                            retPersonIndex = GirlPersonIndex;
                        }
                        break;
                    }
                }
            }
            return retPersonIndex;
        }

        public void beFruitfullAndMultiply(int currentYear)
        {

            foreach (Family myFamily in allFamilies)
            {
                if (BabyTime(myFamily, currentYear))
                {
                    TreePerson MyChild = new TreePerson(TreePerson.PersonType.Unique, currentYear.ToString());
                    int childPersonIndex = myPeople.addToAllPeople(MyChild);
                    myFamily.AddChildIndex(childPersonIndex);
                    addToSinglesList(childPersonIndex, MyChild.Sex);
                    MyChild.BirthFamilyIndex = allFamilies.IndexOf(myFamily);
                }
            }
        }
        public bool BabyTime(Family myFamily, int currentYear)
        {
           // Debug.WriteLine("Are we having a baby?");
            bool retGotaBaby = false;
            // consider Marriage date
            int iMarriageDate;
            if (!Int32.TryParse(myFamily.MarriageDate, out iMarriageDate)) return retGotaBaby;
            if ((currentYear - iMarriageDate) <= _firstChildAfterMarriage) return retGotaBaby;
            //Debug.Log ("Marriage Date looks good");
            // consider we need both a Bride and Groom
            if (myPeople.allPeople[myFamily.GroomPersonIndex].isDead()) return retGotaBaby;
            if (myPeople.allPeople[myFamily.BridePersonIndex].isDead()) return retGotaBaby;
            //Debug.Log ("We have a Bride and Groom!");
            // consider age of Bride

            if (myPeople.allPeople[myFamily.BridePersonIndex].age(currentYear) >= _childBearingAge) return retGotaBaby;
            //Debug.Log ("The Bride is not too old.");
            // consider yougest childs birth year/age
            int iYoungestChildBirth = 0;
            if (myFamily.ChildrenPersonIndexList.Count != 0)
            {
                foreach (int ChildPersonIndex in myFamily.ChildrenPersonIndexList)
                {
                    int iChildBirth;
                    if (!Int32.TryParse(myPeople.allPeople[ChildPersonIndex].Birth, out iChildBirth))
                        return retGotaBaby;
                    if (iChildBirth > iYoungestChildBirth) iYoungestChildBirth = iChildBirth;
                }
                if ((currentYear - iYoungestChildBirth) < _babySpacingYears) return retGotaBaby;
            }
            //Debug.Log ("There has been enough time since the last child!");
            // Okay all is well - lets also throw in a random chance
            int iRand = _3DFamilyTreeFileUtility. RandomNumber.Next(0, 100);
            if (iRand < _chanceForABaby)
            {
                retGotaBaby = true;
                //Debug.WriteLine(myPeople.allPeople[myFamily.BridePersonIndex].Name + " & " +
                //                myPeople.allPeople[myFamily.GroomPersonIndex].Name +
                //                " Are going to have a baby! iRand =" + iRand.ToString());
            }

            return retGotaBaby;
        }

        public int addToAllFamilies(Family family)
        {
            allFamilies.Add(family);
            return allFamilies.IndexOf(family);
        }

        public class mortalityBracket
        {
            public int upToAge;
            // rates per 100000
            public int maleDeathRate;
            public int femaleDeathRate;

            public mortalityBracket(int UpToAge, int MaleDeathRate, int FemaleDeathRate)
            {
                upToAge = UpToAge;
                maleDeathRate = MaleDeathRate;
                femaleDeathRate = FemaleDeathRate;
            }
        }

        public void mortality(int currentYear)
        {
            // Based off of US census Data year 2000
            // U.S. Census Bureau, Statistical Abstract of the United States: 2012
            //https://www.census.gov/compendia/statab/2012/tables/12s0110.pdf
            // Up to age
            mortalityBracket[] mortalityBracketList = new mortalityBracket[5] {
            new mortalityBracket(130, 17501, 14719),
            new mortalityBracket(84, 4977, 3368),
            new mortalityBracket(64, 676, 409),
            new mortalityBracket(34, 77,38),
            new mortalityBracket(1, 807, 663)};

            //int[] mortalityAges = new int[5] {1, 34, 64, 84, 130};

            //int[] mortalityRatesMale = new int[5] {807, 77, 676, 4977, 17501};
            //int[] mortalityRatesFemale = new int[5] {663, 38, 409, 3368, 14719};

            foreach (TreePerson person in myPeople.allPeople)
            {
                if (person.isAlive())
                {
                    int age = person.age(currentYear);

                    #region Determine Mortality Rate
                    int mortalityRate = 100000;  // 100%
                    foreach (mortalityBracket mortalityParameter in mortalityBracketList)
                    {
                        if (age <= mortalityParameter.upToAge)
                        {
                            if (person.Sex == TreePerson.PersonSex.Female)
                            {
                                mortalityRate = mortalityParameter.femaleDeathRate;
                            }
                            else
                            {
                                mortalityRate = mortalityParameter.maleDeathRate;
                            }
                        }
                    }
                    #endregion
                    if (person.isDeathEvent(mortalityRate, currentYear))
                    {
                        person.Death = currentYear.ToString();
                        removeFromSinglesList(myPeople.allPeople.IndexOf(person), person.Sex);
                    }

                }

            }

        }


        public string getAllFamiliesText(int currentYear)
        {
            string retString = "";
            foreach (Family myFamily in allFamilies)
                retString += "#" + allFamilies.IndexOf(myFamily) + "\r\n" + myFamily.GetText(myPeople, currentYear);

            return retString;
        }
    }
}


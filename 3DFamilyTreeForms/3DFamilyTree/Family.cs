using System.Collections.Generic;

namespace _3DFamilyTreeFileUtility
{
    public class Family
    {
        public int Generation;
        public int BridePersonIndex;
        public int GroomPersonIndex;
        public string MarriageDate = "";
        public List<int> ChildrenPersonIndexList;

        /// <summary>
        /// TODO
        /// For the purposes of clustering and creating an 'infinite runner' display list
        /// we need to be able to ask the family object the following:
        /// Give me the list of down generation families (where mom and dad came from)
        /// Give me the list of up generation families (where the children married into)
        /// Give me the list of side generation families (marriage, adoption)

        public Family() : this(0, 0, 0, "") { }

        /// <summary>
        /// Defines the base unit Family with a bride, groom, marriage date and a list of children
        /// </summary>
        /// <param name="generation">What generation this family is relative to the 'startingID' of this descendancy</param>
        /// <param name="bridePersonIndex">Index into MyPeople of the Bride</param>
        /// <param name="groomPersonIndex">Index into MyPeople of the Groom</param>
        /// <param name="marriageDate">A string representation of thier marriage date</param>
        public Family(int generation, int bridePersonIndex, int groomPersonIndex, string marriageDate)
        {
            Generation = generation;
            BridePersonIndex = bridePersonIndex;
            GroomPersonIndex = groomPersonIndex;
            MarriageDate = marriageDate;
            ChildrenPersonIndexList = new List<int>();

        }





        public void AddChildIndex(int childPersonIndex)
        {
            ChildrenPersonIndexList.Add(childPersonIndex);

            //Debug.Log ("New baby is a " + ((child.Sex == Person.PersonSex.Female) ? "Girl" : "Boy") + "!!");
            //Debug.Log ("The baby is named " + child.Name);
        }

        public int marriageDateInt()
        {
            int imarriage = 0;
            if (!int.TryParse(this.MarriageDate, out imarriage))
            {
                imarriage = 0;
            }
            return imarriage;
        }

        public string GetText(MyPeople myPeople, int currentYear)
        {
            string retString = "Family (HOME): Generation " + Generation + "\r\n";
            if (Generation == 0)
            {
                retString += "\tGENERATION ZERO\r\n";
            }
            else
            {
                retString +=
                    "\tBride: " + myPeople.allPeople[BridePersonIndex].GetText(currentYear, BridePersonIndex) +
                    "\r\n" +
                    "\t\tWife's parents family index: " +
                    myPeople.allPeople[BridePersonIndex].BirthFamilyIndex + "\r\n" +
                    "\tGroom: " + myPeople.allPeople[GroomPersonIndex].GetText(currentYear, GroomPersonIndex) +
                    "\r\n" +
                    "\t\tHusband's parents family index: " +
                    myPeople.allPeople[GroomPersonIndex].BirthFamilyIndex + "\r\n" +
                    "\tMarriage: " + MarriageDate + "\r\n";

            }
            foreach (int childPersonIndex in ChildrenPersonIndexList)
            {
                retString += "\t\tChild: " +
                             myPeople.allPeople[childPersonIndex].GetText(currentYear, childPersonIndex) + "\r\n";
            }
            return retString;
        }
    }

}
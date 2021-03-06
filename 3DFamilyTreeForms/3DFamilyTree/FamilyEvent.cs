using System.Collections.Generic;

namespace _3DFamilyTreeFileUtility
{
    public class FamilyEvent
    {
        public string Date = "";
        public FamilyEventType EventType = FamilyEventType.Null;
        public int BridePersonIndex = 0;
        public int GroompersonIndex = 0;
        public int FamilyIndex = 0;
        public int Generation = 0;

        public enum FamilyEventType
        {
            Null,
            Marriage,
            Divorce,
            Adoption
        }

        public FamilyEvent() 
        {
          

        }

        public FamilyEvent(MyPeople myPeople, List<Family> allFamilies, FamilyEventType type, string date, int bridePersonIndex, int groomPersonIndex)
        {
            Date = date;
            EventType = type;
            BridePersonIndex = bridePersonIndex;
            GroompersonIndex = groomPersonIndex;
            Generation = allFamilies[myPeople.allPeople[groomPersonIndex].BirthFamilyIndex].Generation + 1;
        }

        public string GetText()
        {
            string retString = "";
            switch (EventType)
            {
                case FamilyEventType.Marriage:
                    retString = BridePersonIndex + " and " + GroompersonIndex + ", Married on " + Date;
                    break;
                case FamilyEventType.Divorce:
                    retString = BridePersonIndex + " and " + GroompersonIndex + ", Divorced on " + Date;
                    break;
            }

            return retString;
        }

    }

}
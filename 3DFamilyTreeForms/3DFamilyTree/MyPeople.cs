using System.Collections.Generic;

namespace _3DFamilyTreeFileUtility
{
    public class MyPeople
    {
        public List<TreePerson> allPeople;

        public MyPeople()
        {
            allPeople = new List<TreePerson>();
        }

        public void init()
        {
            allPeople.Clear();
        }

        public void Add(TreePerson newPerson)
        {

            allPeople.Add(newPerson);

        }

        public int livingCount()
        {
            int retCount = 0;
            foreach (TreePerson person in allPeople)
            {
                if (person.isAlive()) retCount++;
            }
            return retCount;
        }

        public int addToAllPeople(TreePerson person)
        {
            allPeople.Add(person);
            return allPeople.IndexOf(person);
        }
    }


}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityTreeScripts
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
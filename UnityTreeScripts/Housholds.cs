using UnityEngine;
using System.Collections;

namespace UnityTreeScripts
{
    public class Housholds
    {

        public SortedList homes;

        public void Households()
        {
            SortedList homes = new SortedList();

        }

        public int Count
        {
            get { return this.homes.Count; }

        }

    }

}
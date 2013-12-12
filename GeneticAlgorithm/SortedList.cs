using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticAlgorithm
{
    public class SortedList<T>
        : List<T>
        where T : IComparable
    {
        public new void Add(T Item)
        {
            if (Count == 0) // If the list is empty, add immediately
            {
                this.Insert(0, Item);
                return;
            }
            for (int x = Count - 1; x >= 0; x--) // Insert at correct position
            {
                if (Item.CompareTo(this[x]) >= 0) // If the number to be inserted is bigger than the currently checked one
                {
                    this.Insert(x + 1, Item);
                    return;
                }
            }
            this.Insert(0, Item); // If not inserted, insert at beginning
        }
    }
}

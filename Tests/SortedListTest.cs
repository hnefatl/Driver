using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using GeneticAlgorithm;

namespace Tests
{
    [TestClass]
    public class SortedListTest
    {
        [TestMethod]
        public void TestAdd()
        {
            const int SampleSize = 1000000;

            Random Generator = new Random();

            SortedList<int> Tested = new SortedList<int>();
            List<int> Original = new List<int>();

            for (int x = 0; x < SampleSize; x++)
            {
                Original.Add(x);
            }
            List<int> OriginalClone = new List<int>(Original.ToArray());
            while (OriginalClone.Count > 0)
            {
                int Position = Generator.Next(0, OriginalClone.Count);
                Tested.Add(OriginalClone[Position]);
                OriginalClone.RemoveAt(Position);
            }

            if (Tested.Count != Original.Count)
            {
                throw new Exception("Count mismatch.");
            }

            for (int x = 0; x < Tested.Count; x++)
            {
                if (Tested[x] != Original[x])
                {
                    throw new Exception("Order mismatch.");
                }
            }
        }
    }
}

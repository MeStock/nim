using System;
using System.Collections;

namespace nim
{
    public class Heaps
    {
        public int heap1 { get; set; }
        public int heap2 { get; set; }
        public int heap3 { get; set; }

        public Heaps()
        {
            heap1 = GenerateNewRandomHeap();
            heap2 = GenerateNewRandomHeap();
            heap3 = GenerateNewRandomHeap();
        }

        public int GenerateNewRandomHeap()
        {
            Random rnd = new Random();
            int amountOfStones= rnd.Next(1, 20);
            return amountOfStones;
        }

        public void UpdateNumberOfStones(int amountToRemove, int heapToRemoveFrom)
        {
            switch (heapToRemoveFrom)
            {
                case 1:
                    heap1 -= amountToRemove;
                    break;
                case 2:
                    heap1 -= amountToRemove;
                    break;
                case 3:
                    heap1 -= amountToRemove;
                    break;
            }
        }
    }
}

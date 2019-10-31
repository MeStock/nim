using System;
using System.Collections;

namespace nim
{
    public class Heaps
    {
        public int heap1;
        public int heap2;
        public int heap3;
        public Heaps()
        {
            this.heap1 = GenerateNewRandomHeap();
            this.heap2 = GenerateNewRandomHeap();
            this.heap3 = GenerateNewRandomHeap();
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
        public bool CheckIfValidMove(int amountToRemove, int heapToRemoveFrom)
        {
            if (heapToRemoveFrom - amountToRemove < 0) return false;
            return true;
        }
    }
}

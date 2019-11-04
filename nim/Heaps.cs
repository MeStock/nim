using System;

namespace nim
{
    public class Heaps
    {
        public static int Heap1 { get; set; }
        public static int Heap2 { get; set; }
        public static int Heap3 { get; set; }

        public Heaps()
        {
            Heap1 = GenerateNewRandomHeap();
            Heap2 = GenerateNewRandomHeap();
            Heap3 = GenerateNewRandomHeap();
        }

        public int GenerateNewRandomHeap()
        {
            Random rnd = new Random();
            int amountOfStones = rnd.Next(1, 20);
            return amountOfStones;
        }

        public static void UpdateNumberOfStones(int amountToRemove, int heapToRemoveFrom)
        {
            switch (heapToRemoveFrom)
            {
                case 0:
                    Heap1 -= amountToRemove;
                    break;
                case 1:
                    Heap2 -= amountToRemove;
                    break;
                case 2:
                    Heap3 -= amountToRemove;
                    break;
            }
        }
    }
}

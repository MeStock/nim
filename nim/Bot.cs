using System;
namespace nim
{
    public class Bot
    {
        public static int CalculateNimSum()
        {
            return Heaps.Heap1 ^ Heaps.Heap2 ^ Heaps.Heap3;
        }

        public static void Turn()
        {
            int nimSum = CalculateNimSum();
            int[] remainingStones = { Heaps.Heap1, Heaps.Heap2, Heaps.Heap3 };
            bool isValidMove;

            if (nimSum != 0)
            {
                for (int i = 0; i < Game.NUMBER_OF_PILES; i++)
                {
                    isValidMove = Game.CheckIfValidMove((remainingStones[i] ^ nimSum), i);
                    if ((remainingStones[i] ^ nimSum) < remainingStones[i] && isValidMove)
                    {
                        Heaps.UpdateNumberOfStones((remainingStones[i] ^ nimSum), i);
                        break;
                    }
                }
            }
            else
            {
                Random rnd = new Random();
                int randomAmountToRemove;
                int heapToRemoveFrom;
                do
                {
                    randomAmountToRemove = rnd.Next(1,20);
                    heapToRemoveFrom = rnd.Next(0, 3);
                    isValidMove = Game.CheckIfValidMove(randomAmountToRemove, heapToRemoveFrom);
                }
                while (!isValidMove);
                Heaps.UpdateNumberOfStones(randomAmountToRemove, heapToRemoveFrom);
            }
        }

        public static void PredictWinner(string whoseTurn)
        {
            Console.WriteLine("Based on the values in these piles, if both players play optimally...");
            if (CalculateNimSum() != 0)
            {
                if (whoseTurn == "Player"){ Console.WriteLine("You will win!"); }
                else { Console.WriteLine("The computer will win"); }
            }
            else
            {
                if (whoseTurn == "Player") { Console.WriteLine("The computer will win"); }
                else { Console.WriteLine("You will win!"); }
            }
            Console.WriteLine();
        }
    }
}

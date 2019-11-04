using System;
namespace nim
{
    public class Bot
    {
        public Bot()
        {
        }

        public int CalculateNimSum()
        {
            return Heaps.Heap1 ^ Heaps.Heap2 ^ Heaps.Heap3;
        }

        public void Turn()
        {
            int nimSum = CalculateNimSum();
            int[] remainingStones = { Heaps.Heap1, Heaps.Heap2, Heaps.Heap3 };

            if (nimSum != 0)
            {
                for (int i = 0; i < Game.NUMBER_OF_PILES; i++)
                {
                    if ((remainingStones[i] ^ nimSum) < remainingStones[i])
                    {

                    }
                }
            }
            else
            {

            }
        }

        public void PredictWinner(string whoseTurn)
        {
            Console.WriteLine("Based on the values in these piles, if both players play optimally.....");
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

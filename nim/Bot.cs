using System;
namespace nim
{
    public class Bot
    {
        public static double easyPercent = 0.25;
        public static double mediumPercent = 0.50;
        public static Random rnd = new Random();

        public static int CalculateNimSum()
        {
            return Heaps.Heap1 ^ Heaps.Heap2 ^ Heaps.Heap3;
        }

        public static void Turn(Difficulty selectedDifficulty)
        {
            double percentToChooseOptimalMove = rnd.Next(0,1);
            switch (selectedDifficulty)
            {
                case Difficulty.Easy:
                    if (percentToChooseOptimalMove <= easyPercent) { MakeOptimalMove(); }
                    else { MakeRandomMove(); }
                    break;
                case Difficulty.Medium:
                    if (percentToChooseOptimalMove <= mediumPercent) { MakeOptimalMove(); }
                    else { MakeRandomMove(); }
                    break;
                case Difficulty.Hard:
                    MakeOptimalMove();
                    break;
            }
        }

        public static void MakeOptimalMove()
        {
            int nimSum = CalculateNimSum();
            int[] remainingStones = { Heaps.Heap1, Heaps.Heap2, Heaps.Heap3 };
            bool isValidMove;

            if (nimSum != 0)
            {
                for (int i = 0; i < remainingStones.Length; i++)
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
                MakeRandomMove();
            }
        }

        public static void MakeRandomMove()
        {
            int randomAmountToRemove;
            int heapToRemoveFrom;
            bool isValidMove;
            do
            {
                randomAmountToRemove = rnd.Next(1, 50);
                heapToRemoveFrom = rnd.Next(0, 3);
                isValidMove = Game.CheckIfValidMove(randomAmountToRemove, heapToRemoveFrom);
            }
            while (!isValidMove);
            Heaps.UpdateNumberOfStones(randomAmountToRemove, heapToRemoveFrom);
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

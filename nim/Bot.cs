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

            if (nimSum != 0)
            {
                for (int i = 0; i < remainingStones.Length; i++)
                {
                    if ((remainingStones[i] ^ nimSum) < remainingStones[i])
                    {
                        int amountToRemove = remainingStones[i] - (remainingStones[i] ^ nimSum);
                        Render.ClearLine();
                        Console.WriteLine($"Computer removed {amountToRemove} stones from pile {i + 1}");
                        Heaps.UpdateNumberOfStones(amountToRemove, i);
                        break;
                    }
                    if (i == remainingStones.Length - 1) { MakeRandomMove(); }
                }
            }
            else
            {
                MakeRandomMove();
            }
        }

        public static void MakeRandomMove()
        {
            int randomAmountToRemove = -1;
            int heapToRemoveFrom = -1;
            bool isValidMove = false;
            while (!isValidMove)
            {
                randomAmountToRemove = rnd.Next(1, Game.MAX_STONES);
                heapToRemoveFrom = rnd.Next(0, 3);
                isValidMove = Game.CheckIfValidMove(randomAmountToRemove, heapToRemoveFrom);
            }
            Render.ClearLine();
            Console.WriteLine($"Computer removed {randomAmountToRemove} stones from pile {heapToRemoveFrom + 1}");
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

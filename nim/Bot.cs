using System;
namespace nim
{
    public class Bot
    {
        public static double easyPercent = 0.25; //25% chance the computer will chose the optimal move
        public static double mediumPercent = 0.50; //50% chance the computer will chose the optimal move
        public static Random rnd = new Random();

        public static int CalculateNimSum()
        {
            return Heaps.Heap1 ^ Heaps.Heap2 ^ Heaps.Heap3; //XOR sum - used to calculate optimal move
        }

        public static void Turn(Difficulty selectedDifficulty)
        {
            double percentToChooseOptimalMove = rnd.Next(0,1); //Used to determine if the computer will make an optimal move
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
        /*
         Algorithm Source: https://www.geeksforgeeks.org/combinatorial-game-theory-set-2-game-nim/
         
         Based on the number of stones -  calculate the nim sum (aka binary sum ignoring the carries)

            If the Nim Sum does not equal zero - find a way to make it zero:
                Check the XOR between each value and the nim sum
                If this value is less than the value in the pile - reduce the pile to this number

                Example: piles = {3, 4, 5}
                nim sum = 3 ^ 4 ^ 5 = 2

                3 ^ 2 = 1  <---- Since 1 < 3, we want to reduce this pile to 1 (remove 2 stones from pile 1)
                4 ^ 2 = 6
                5 ^ 2 = 7

                Why? Because 1 ^ 4 ^ 5 = 0 and ending your turn with a nim sum of 0 is a winning position

            However, if the nim sum starts at zero - its been mathematically proven that you will lose.
            Therefore, make a random move and hope your opponent makes a mistake
        */
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
                }
            }
            else
            {
                MakeRandomMove();
            }
        }

        public static void MakeRandomMove()
        {
            int randomAmountToRemove = -1; //Start at invalid amount & heap
            int heapToRemoveFrom = -1;
            bool isValidMove = false;
            while (!isValidMove) //Make sure move is valid before updating board
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

using System;
namespace nim
{
    public enum Difficulty { Easy = 1, Medium, Hard}
    public class Game
    {
        public static Game currentGame = new Game();
        public static Heaps currentHeaps = new Heaps();
        public static bool gameRunning = true;

        public static void StartGame()
        {
            WelcomePage.WriteBanner();
            WelcomePage.StartWithRules();
            Difficulty difficulty  = AskForDifficulty();
            while (gameRunning)
            {
                RenderGame();
                Player.Turn();
                gameRunning &= !CheckForWinner();
            }
        }

        public static Difficulty AskForDifficulty()
        {
            bool isValidSelection;
            Difficulty selectedDifficulty;
            do
            {
                WelcomePage.WriteDifficultyOptions();
                string userInput = Console.ReadLine();
                isValidSelection = Enum.TryParse<Difficulty>(userInput, true, out selectedDifficulty);
            } while (!isValidSelection);
            Console.Clear();
            return selectedDifficulty;

        }

        public static void RenderGame()
        {
            Console.WriteLine("Your turn: ");
            Console.WriteLine("Select a pile by moving with the arrow keys and hitting enter");
            Console.WriteLine("Then enter the amount you want to remove");
            Console.WriteLine();
            Console.Write(
                $"  |_{currentHeaps.heap1}_|     |_{currentHeaps.heap2}_|     |_{currentHeaps.heap3}_|"
                );
            Console.WriteLine();
        }

        public static bool CheckIfValidMove(int amountToRemove, int heapToRemoveFrom)
        {
            int[] remainingStones = { currentHeaps.heap1, currentHeaps.heap2, currentHeaps.heap3 };
            if (remainingStones[heapToRemoveFrom] - amountToRemove < 0) { return false; }
            return true;
        }

        public static bool CheckForWinner()
        {
            if (currentHeaps.heap1 == 0 && currentHeaps.heap2 == 0 && currentHeaps.heap3 == 0) { return true; }
            return false;
        }
    }
}

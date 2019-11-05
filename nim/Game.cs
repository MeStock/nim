using System;
namespace nim
{
    public enum Difficulty { Easy = 1, Medium, Hard }
    public class Game
    {
        public static Heaps currentHeaps = new Heaps();
        public static Game currentGame = new Game();
        public static string[] Board { get; set; }
        public static string whoseTurn = "Player";
        public static bool gameRunning = true;
        public static int MAX_STONES = 10;

        public Game()
        {
            Board = new string[] { $"  |_{Heaps.Heap1}_|   ", $"  |_{Heaps.Heap2}_|   ", $"  |_{Heaps.Heap3}_|    " };
        }

        public static void StartGame()
        {
            WelcomePage.WriteBanner();
            WelcomePage.StartWithRules();
            Difficulty difficulty = AskForDifficulty();
            Bot.PredictWinner(whoseTurn);
            Console.WriteLine();
            Render.Game(Board);
            while (gameRunning)
            {
                if (whoseTurn == "Player")
                {
                    Player.Turn();
                    whoseTurn = "Bot";
                }
                else
                {
                    Bot.Turn(difficulty);
                    whoseTurn = "Player";
                }
                UpdateBoard();
                gameRunning &= !CheckForWinner();
            }
            EndGameMessage(whoseTurn);
        }

        public static Difficulty AskForDifficulty()
        {
            Difficulty selectedDifficulty;
            bool isValidSelection;
            bool isDefinedEnum = false;
            do
            {
                WelcomePage.WriteDifficultyOptions();
                string userInput = Console.ReadLine();
                isValidSelection = Enum.TryParse<Difficulty>(userInput, true, out selectedDifficulty);
                if (isValidSelection) { isDefinedEnum = Enum.IsDefined(typeof(Difficulty), selectedDifficulty); }
                if (!isValidSelection || !isDefinedEnum) { Console.WriteLine("Invalid difficulty"); }
                Console.Clear();
            } while (!isValidSelection || !isDefinedEnum);
            ExplainRules();
            return selectedDifficulty;
        }

        public static bool CheckIfValidMove(int amountToRemove, int heapToRemoveFrom)
        {
            int[] remainingStones = { Heaps.Heap1, Heaps.Heap2, Heaps.Heap3 };
            if (remainingStones[heapToRemoveFrom] - amountToRemove < 0) { return false; }
            return true;
        }

        public static bool CheckForWinner()
        {
            if (Heaps.Heap1 == 0 && Heaps.Heap2 == 0 && Heaps.Heap3 == 0) { return true; }
            return false;
        }

        public static void ExplainRules()
        {
            Console.WriteLine("Select a pile by moving with the arrow keys and hitting enter");
            Console.WriteLine("Then enter the amount you want to remove");
            Console.WriteLine();
        }

        public static void EndGameMessage(string whoseTurn)
        {
            Console.Clear();
            Console.WriteLine("Game Over");
            if (whoseTurn == "Bot") { Console.WriteLine("Congrats! You beat the computer :)"); }
            else { Console.WriteLine("Sorry, you lost to the computer :("); }
        }

        public static void UpdateBoard()
        {
            Board = new string[] { $"  |_{Heaps.Heap1}_|   ", $"  |_{Heaps.Heap2}_|   ", $"  |_{Heaps.Heap3}_|    " };
            Render.Game(Board);
        }
    }
}

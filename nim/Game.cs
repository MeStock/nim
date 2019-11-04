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

        public Game()
        {
            Board = new string[] { $"  |_{Heaps.Heap1}_|   ", $"  |_{Heaps.Heap2}_|   ", $"  |_{Heaps.Heap3}_|    " };
        }

        public static void StartGame()
        {
            WelcomePage.WriteBanner();
            WelcomePage.StartWithRules();
            Difficulty difficulty  = AskForDifficulty();
            Bot.PredictWinner(whoseTurn);
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
            bool isValidSelection;
            Difficulty selectedDifficulty;
            do
            {
                WelcomePage.WriteDifficultyOptions();
                string userInput = Console.ReadLine();
                isValidSelection = Enum.TryParse<Difficulty>(userInput, true, out selectedDifficulty);
                if (!isValidSelection) { Console.WriteLine("Invalid difficulty"); }
            } while (!isValidSelection);
            Console.Clear();
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
            string winner, loser;
            if (whoseTurn == "Player") {  winner = "Sorry! the computer";  loser = "you"; }
            else {  winner = "Congrats! You";  loser = "the computer"; }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Game Over");
            Console.WriteLine($"{winner} beat {loser}");
        }

        public static void UpdateBoard()
        {
            Board = new string[] { $"  |_{Heaps.Heap1}_|   ", $"  |_{Heaps.Heap2}_|   ", $"  |_{Heaps.Heap3}_|    " };
            Render.Game(Board);
        }
    }
}

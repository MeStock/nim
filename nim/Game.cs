using System;
namespace nim
{
    public enum Difficulty { Easy = 1, Medium, Hard }
    public class Game
    {
        public static Heaps currentHeaps = new Heaps();
        public static Game currentGame = new Game();
        public static string[] Board { get; set; }
        public static bool gameRunning = true;
        public static string whoseTurn = "Player"; //The user always goes first
        public static int MAX_STONES = 10; //Max number of stones in one heap - can be changed to any number

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
                    whoseTurn = "Bot"; //After players turn - change player to computer
                }
                else
                {
                    Bot.Turn(difficulty);
                    whoseTurn = "Player"; //After computers turn - change player to user
                }
                UpdateBoard();
                gameRunning = !CheckForWinner(); //After each turn - check if there is a winner & determine if the game is still running
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
                isValidSelection = Enum.TryParse<Difficulty>(Console.ReadLine(), true, out selectedDifficulty); //This checks if the user input is easy, medium, or hard - not case sensitive
                if (isValidSelection) { isDefinedEnum = Enum.IsDefined(typeof(Difficulty), selectedDifficulty); } //This checks if the user input is 1, 2, or 3
                if (!isValidSelection || !isDefinedEnum) { Console.WriteLine("Invalid difficulty"); }
                Console.Clear();
            } while (!isValidSelection || !isDefinedEnum);//Ask for valid input as long as the user has not entered easy, medium, hard, 1, 2, or 3
            ExplainHowToUseKeyboardToPlay(); 
            return selectedDifficulty;
        }

        public static bool CheckIfValidMove(int amountToRemove, int heapToRemoveFrom)
        {
            int[] remainingStones = { Heaps.Heap1, Heaps.Heap2, Heaps.Heap3 };
            if (amountToRemove == 0) { return false; } //You must take at least one stone
            if (remainingStones[heapToRemoveFrom] - amountToRemove < 0) { return false; } //A move cannot leave a pile with less that zero stones
            return true;
        }

        public static bool CheckForWinner()
        {
            if (Heaps.Heap1 == 0 && Heaps.Heap2 == 0 && Heaps.Heap3 == 0) { return true; }
            return false;
        }

        public static void ExplainHowToUseKeyboardToPlay()
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

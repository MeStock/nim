using System;
namespace nim
{
    public enum Difficulty { Easy = 1, Medium, Hard }
    public class Game
    {
        public static Heaps currentHeaps = new Heaps();
        public static Game currentGame = new Game();
        public static string[] Board { get; set; }
        public static string whoseTurn { get; set; }
        public static bool gameRunning = true;
        public static Difficulty difficulty;
        public static readonly int MAX_STONES = 10; //Max number of stones in one heap - can be changed to any number

        public Game()
        {
            Board = new string[] { $"  |_{Heaps.Heap1}_|   ", $"  |_{Heaps.Heap2}_|   ", $"  |_{Heaps.Heap3}_|    " };
        }

        public static void StartGame()
        {
            WelcomePage.WriteBanner();
            WelcomePage.StartWithRules();
            AskForHowManyPlayers();
            if (whoseTurn == "You") { difficulty = AskForDifficulty(); }
            Bot.PredictWinner(whoseTurn);
            Console.WriteLine();
            Render.Game(Board);
            while (gameRunning)
            {
                if (whoseTurn == "You")
                {
                    Player.Turn();
                    whoseTurn = "Computer"; //After players turn - change player to computer
                }
                else if (whoseTurn == "Computer")
                {
                    Bot.Turn(difficulty);
                    whoseTurn = "You"; //After computers turn - change player to user

                }
                else if (whoseTurn == "Player1")
                {
                    Player.Turn();
                    whoseTurn = "Player2";
                }
                else
                {
                    Player.Turn();
                    whoseTurn = "Player1";
                }
                UpdateBoard();
                gameRunning &= !CheckForWinner(); //After each turn - check if there is a winner & determine if the game is still running
            }
            EndGameMessage(whoseTurn);
        }

        public static void AskForHowManyPlayers()
        {
            bool isValidSelection = false;
            int selectedMode = 0;
            while (!isValidSelection || selectedMode < 1 || selectedMode > 3)
            {
                Console.WriteLine("Please select which mode you would like to try: ");
                Console.WriteLine("1. You v.s. the Computer");
                Console.WriteLine("2. You v.s. a Friend");
                isValidSelection = int.TryParse(Console.ReadLine(), out selectedMode);
                if (!isValidSelection) { Console.WriteLine("Invalid Mode"); }
                Console.Clear();
            }
            if (selectedMode == 1) { whoseTurn = "You"; }
            else { whoseTurn = "Player1"; }
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
            if (remainingStones[heapToRemoveFrom] - amountToRemove < 0) { return false; } //A move cannot result in a pile with negative stones
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

        //Computer vs Computer - Use to demo that the prediction method is accurate
        public static void Demo()
        {
            whoseTurn = "Computer1";
            Console.WriteLine($"NimSum: {Bot.CalculateNimSum()}");
            while (gameRunning)
            {
                if (whoseTurn == "Computer1")
                {
                    Bot.Turn(Difficulty.Hard);
                    whoseTurn = "Computer2";
                }
                else
                {
                    Bot.Turn(Difficulty.Hard);
                    whoseTurn = "Computer1";
                }
                UpdateBoard();
                gameRunning &= !CheckForWinner();
            }
            Console.WriteLine($"{whoseTurn} lost!");
        }
    }
}

using System;
namespace nim
{
    public enum Difficulty { Easy = 1, Medium, Hard}
    public class Game
    {
        public static Game currentGame = new Game();
        public static Heaps currentHeaps = new Heaps();

        public static int BOARD_HEIGHT = 3;

        public static void StartGame()
        {
            WelcomePage.WriteBanner();
            WelcomePage.StartWithRules();
            Difficulty difficulty  = GetDifficulty();
            RenderGame(difficulty);
            while (true)
            {
                bool userInput = int.TryParse();
                if (CheckForWinner()) break;
            }
        }

        public static Difficulty GetDifficulty()
        {
            bool isValidSelection;
            Difficulty selectedDifficulty;
            do
            {
                Console.WriteLine("Please select your difficulty:");
                Console.WriteLine("1. Easy");
                Console.WriteLine("2. Medium");
                Console.WriteLine("3. Hard");
                string userInput = Console.ReadLine();
                isValidSelection = Enum.TryParse<Difficulty>(userInput, true, out selectedDifficulty);
            } while (!isValidSelection);
            Console.Clear();
            return selectedDifficulty;

        }

        public static void RenderGame(Difficulty difficulty)
        {
           
            Console.Write(
                $"  |_{currentHeaps.heap1}_|     |_{currentHeaps.heap2}_|     |_{currentHeaps.heap3}_|"
                );
        }

        public static void UserTurn()
        {
            bool validMove = false;
            bool validInput = false;
            int userInput;
            Console.WriteLine("Your turn: Select a pile and enter the amount of items you would like to remove");
            while (!validMove || !validInput)
            {
                validInput = int.TryParse(Console.ReadLine(), out userInput);
                if (validInput) { validMove = CheckIfValidMove(userInput, Console.ReadKey()); }
            }
        }

        public bool CheckIfValidMove(int amountToRemove, int heapToRemoveFrom)
        {
            if (heapToRemoveFrom - amountToRemove < 0) { return false; }
            return true;
        }

        public static bool CheckForWinner()
        {
            return false;
        }
    }
}

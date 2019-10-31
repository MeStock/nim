using System;
namespace nim
{
    public class Game
    {
        Game currentGame = new Game();

        public static void StartGame()
        {
            int difficulty  = GetDifficulty();
            while (true)
            {
                if (CheckForWinner()) break;
            }
        }

        public static int GetDifficulty()
        {
            bool isValidSelection;
            int selectedDifficulty;
            do
            {
                Console.WriteLine("Please select your difficulty:");
                Console.WriteLine("Enter 1 for Easy");
                Console.WriteLine("Enter 2 for Medium");
                Console.WriteLine("Enter 3 for Hard");
                isValidSelection = int.TryParse(Console.ReadLine(), out selectedDifficulty);
            } while (!isValidSelection || selectedDifficulty < 1 || selectedDifficulty > 3);
            return selectedDifficulty;

        }

        public static void RenderGame(int difficulty)
        {

        }

        public bool CheckValidMove(int amountToRemove, int heapToRemoveFrom)
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

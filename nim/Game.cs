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
            Difficulty difficulty  = GetDifficulty();
            while (gameRunning)
            {
                RenderGame();
                UserTurn();
                if (CheckForWinner()) { gameRunning = false; }
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

        public static void UserTurn()
        {
            ConsoleKeyInfo userKey;
            bool validMove = false;
            bool validInput = false;
            int locationX = 0;

            while (!validInput && !validMove)
            {
                while (Console.ReadKey().Key != ConsoleKey.Enter)
                {
                        Console.WriteLine("Inside loop");

                        userKey = Console.ReadKey();
                        switch (userKey.Key)
                        {
                            case ConsoleKey.LeftArrow:
                                Console.WriteLine($"{locationX}");
                                if (locationX > 0) { locationX -= 1; }
                                break;
                            case ConsoleKey.RightArrow:
                                Console.WriteLine($"{locationX}");
                                if (locationX < 2) { locationX += 1; }
                                break;
                    }
                }
                int selectedHeap = locationX;
                validInput = int.TryParse(Console.ReadLine(), out int amountToRemove);
                validMove = CheckIfValidMove(amountToRemove, selectedHeap);
            }
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

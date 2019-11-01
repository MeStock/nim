using System;
namespace nim
{
    public static class Player
    {
        public static void Turn()
        {
            bool validMove = false;
            bool validInput = false;

            while (!validInput && !validMove)
            {
                int selectedHeap = GetSelectedHeap();
                validInput = int.TryParse(Console.ReadLine(), out int amountToRemove);
                validMove = Game.CheckIfValidMove(amountToRemove, selectedHeap);
                if (!validMove && validInput) { Console.WriteLine($"Invalid move - that pile does not have {amountToRemove} stones in it"); }
                if (!validMove && !validInput) { Console.WriteLine($"Invalid move -  please enter an integer value"); }
            }
        }

        public static int GetSelectedHeap()
        {
            ConsoleKeyInfo userKey;
            int locationX = 0;

            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
                userKey = Console.ReadKey();
                switch (userKey.Key)
                {
                    case ConsoleKey.LeftArrow:
                        if (locationX > 0) { locationX -= 1; }
                        break;
                    case ConsoleKey.RightArrow:
                        if (locationX < 2) { locationX += 1; }
                        break;
                }
            }
            return locationX;
        }
    }
}

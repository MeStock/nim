using System;
namespace nim
{
    public static class Player
    {
        public static int SelectedHeap { get; set; }

        public static void Turn()
        {
            bool validMove = false;
            bool validNumber = false;
            int amountToRemove = 0;

            while (!validNumber && !validMove)
            {
                SelectedHeap = GetSelectedHeap();
                validNumber = int.TryParse(Console.ReadLine(), out amountToRemove);
                validMove = Game.CheckIfValidMove(amountToRemove, SelectedHeap);
                if (!validMove && validNumber) { Console.WriteLine($"Invalid move - that pile does not have {amountToRemove} stones in it"); }
                if (!validMove && !validNumber) { Console.WriteLine($"Invalid move -  please enter an integer value"); }
            }
            Heaps.UpdateNumberOfStones(amountToRemove, SelectedHeap);
        }

        public static int GetSelectedHeap()
        {
            Console.SetCursorPosition(0, Console.CursorTop);
            ConsoleKeyInfo userKey;
            int locationX = 0;
            bool selectionWasMade = false;

            while (!selectionWasMade)
            {
                userKey = Console.ReadKey();
                switch (userKey.Key)
                {
                    case ConsoleKey.LeftArrow:
                        if (locationX > 0) { locationX -= 1; }
                        Game.UpdateBoard(Game.board ,locationX);
                        break;
                    case ConsoleKey.RightArrow:
                        if (locationX < 2) { locationX += 1; }
                        Game.UpdateBoard(Game.board, locationX);
                        break;
                    case ConsoleKey.Enter:
                        selectionWasMade = true;
                        break;
                }
            }
                return locationX;
        }
    }
}

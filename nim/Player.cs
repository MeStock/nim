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

            while (!validNumber && !validMove && amountToRemove < 1)
            {
                SelectedHeap = GetSelectedHeap();
                validNumber = int.TryParse(Console.ReadLine(), out amountToRemove);
                validMove = Game.CheckIfValidMove(amountToRemove, SelectedHeap);
                if (!validMove && validNumber) { Console.WriteLine($"Invalid move - that pile does not have {amountToRemove} stones in it"); amountToRemove = 0; }
                else if(!validMove && !validNumber) { Console.WriteLine($"Invalid move -  please enter an integer value"); }
                else if(validNumber && amountToRemove < 1) { Console.WriteLine("Invalid move - You must take at least one stone"); }
            }
            Heaps.UpdateNumberOfStones(amountToRemove, SelectedHeap);
        }

        public static int GetSelectedHeap()
        {
            Console.SetCursorPosition(0, Console.CursorTop);
            ConsoleKeyInfo userKey;
            int heapNumber = 0;
            bool heapWasSelected = false;

            while (!heapWasSelected)
            {
                userKey = Console.ReadKey();
                switch (userKey.Key)
                {
                    case ConsoleKey.LeftArrow:
                        if (heapNumber > 0) { heapNumber -= 1; }
                        Game.HoverOverSelectedHeap(Game.Board ,heapNumber);
                        break;
                    case ConsoleKey.RightArrow:
                        if (heapNumber < 2) { heapNumber += 1; }
                        Game.HoverOverSelectedHeap(Game.Board, heapNumber);
                        break;
                    case ConsoleKey.Enter:
                        heapWasSelected = true;
                        break;
                }
            }
                return heapNumber;
        }
    }
}

using System;
namespace nim
{
    public static class Player
    {
        public static int SelectedHeap { get; set; }
        public static int CURSOR_TOP = 5;
        public static int CURSOR_LEFT = 6;

        public static void Turn()
        {
            bool validMove = false;
            bool validNumber = false;
            int amountToRemove = 0;

            while (!validNumber || !validMove || amountToRemove < 1)
            {
                SelectedHeap = GetSelectedHeap();
                AskForUserInput();
                validNumber = int.TryParse(Console.ReadLine(), out amountToRemove);
                validMove = Game.CheckIfValidMove(amountToRemove, SelectedHeap);
                if (!validNumber) { amountToRemove = AskForValidNumber(); }
                else if (!validMove) { amountToRemove = AskForValidMove(amountToRemove); }
                else if(amountToRemove < 1) { AskForAtLeastOne(); }
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
                userKey = Console.ReadKey(true);
                switch (userKey.Key)
                {
                    case ConsoleKey.LeftArrow:
                        if (heapNumber > 0) { heapNumber -= 1; }
                        Render.HoverOverSelectedHeap(Game.Board ,heapNumber);
                        break;
                    case ConsoleKey.RightArrow:
                        if (heapNumber < 2) { heapNumber += 1; }
                        Render.HoverOverSelectedHeap(Game.Board, heapNumber);
                        break;
                    case ConsoleKey.Enter:
                        heapWasSelected = true;
                        break;
                    default:
                        Console.Beep();
                        break;
                }
            }
                return heapNumber;
        }

        public static void AskForUserInput()
        {
            Console.SetCursorPosition(CURSOR_TOP, CURSOR_LEFT);
            Render.ClearLine();
            Console.Write("How many would you like to remove? ");
        }

        public static int AskForValidNumber()
        {
            Render.ClearLine();
            Console.WriteLine($"Invalid move -  please enter an integer value");
            Game.UpdateBoard();
            return 0;
        }

        public static int AskForValidMove(int amountToRemove)
        {
            Render.ClearLine();
            Console.WriteLine($"Invalid move - that pile does not have {amountToRemove} stones in it");
            Game.UpdateBoard();
            return 0;
        }

        public static void AskForAtLeastOne()
        {
            Render.ClearLine();
            Console.WriteLine("Invalid move - You must take at least one stone");
            Game.UpdateBoard();
        }
    }
}

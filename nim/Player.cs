using System;
namespace nim
{
    public static class Player
    {
        public static int SelectedHeap { get; set; }
        public static int CURSOR_TOP = 5; //cursortop & cursorleft are place holders for the error messages - incase of invalid
        public static int CURSOR_LEFT = 6; //user input the cursor will move & write the message without disrupting the game

        public static void Turn()
        {
            bool validMove = false;
            bool validNumber = false;
            int amountToRemove = 0;

            while (!validNumber || !validMove) //User must enter an integer that is a valid move
            {
                SelectedHeap = GetSelectedHeap();
                AskForUserInput();
                validNumber = int.TryParse(Console.ReadLine(), out amountToRemove); //Check if user gave an integer value
                validMove = Game.CheckIfValidMove(amountToRemove, SelectedHeap); //Check if that integer value is a valid move
                if (!validNumber) { amountToRemove = AskForValidNumber(); } //Lines22-23: error messages for invalid input
                else if (!validMove) { amountToRemove = AskForValidMove(amountToRemove); }
            }
            Heaps.UpdateNumberOfStones(amountToRemove, SelectedHeap);
        }
        /*
            While the user is deciding on which pile to select
            "Hover" over the pile of interest to reflect user input is being monitored

            Left and Right arrow keys will display a hovering effect over the pile
            Enter key will stop the loop and return the last pile
            Any other key will Console.Beep to inform the user to use the allowed keys
        */
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
                        if (heapNumber > 0) { heapNumber -= 1; } //There are only 3 piles - 0, 1, 2 - Therefore you cannot move past 0 to the left
                        else { Console.Beep(); }
                        Render.HoverOverSelectedHeap(Game.Board ,heapNumber);
                        break;
                    case ConsoleKey.RightArrow:
                        if (heapNumber < 2) { heapNumber += 1; } //There are only 3 piles - 0, 1, 2 - Therefore you cannot move past 2 to the right
                        else { Console.Beep(); }
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
            //reset the cursor position before clearing & writing the line to not interupt the game
            Console.SetCursorPosition(CURSOR_TOP, CURSOR_LEFT); 
            Render.ClearLine();
            Console.Write("How many would you like to remove? ");
        }

        public static int AskForValidNumber()
        {
            Render.ClearLine();
            Console.WriteLine($"Invalid move -  please enter an integer value");
            Game.UpdateBoard();
            return 0; //Because zero is an invalid move, it was chosen to prompt the user for a valid input
        }

        public static int AskForValidMove(int amountToRemove)
        {
            Render.ClearLine();
            Console.WriteLine($"Invalid move - that pile does not have {amountToRemove} stones in it");
            Game.UpdateBoard();
            return 0; //Because zero is an invalid move, it was chosen to prompt the user for a valid input
        }

        public static void AskForAtLeastOne()
        {
            Render.ClearLine();
            Console.WriteLine("Invalid move - You must take at least one stone");
            Game.UpdateBoard();
        }
    }
}

using System;
namespace nim
{
    public static class Render
    {
        public static void Game(string[] heaps)
        {
            ClearLine();
            for (int i = 0; i < heaps.Length; i++)
            {
                if (i == 0) //Always start by hovering over the first pile
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(heaps[i]);
                    Console.ResetColor();
                }
                else
                {
                    Console.Write(heaps[i]);
                }
            }
        }

        public static void ClearLine() //Remove the last writen line
        {
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop - (Console.WindowWidth >= Console.BufferWidth ? 1 : 0));
        }

        public static void HoverOverSelectedHeap(string[] heaps, int selectedHeap)
        {
            ClearLine(); //Clear and rewrite the line as the user uses the left & right arrow keys
            ClearLine();
            for (int i = 0; i < heaps.Length; i++)
            {
                if (i == selectedHeap)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(heaps[i]);
                    Console.ResetColor();
                }
                else
                {
                    Console.Write(heaps[i]);
                }
            }
        }
    }
}

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
                if (i == 0)
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

        public static void ClearLine()
        {
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop - (Console.WindowWidth >= Console.BufferWidth ? 1 : 0));
        }

        public static void HoverOverSelectedHeap(string[] heaps, int selectedHeap)
        {
            ClearLine();
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

﻿using System;
namespace nim
{
    public enum Difficulty { Easy = 1, Medium, Hard}
    public class Game
    {
        public static Heaps currentHeaps = new Heaps();
        public static Game currentGame = new Game();
        public static string[] Board { get; set; }
        public static bool gameRunning = true;

        public Game()
        {
            Board = new string[]{ $"  |_{Heaps.Heap1}_|   ", $"  |_{Heaps.Heap2}_|   ", $"  |_{Heaps.Heap3}_|    " };
        }

        public static void StartGame()
        {
            WelcomePage.WriteBanner();
            WelcomePage.StartWithRules();
            Difficulty difficulty  = AskForDifficulty();
            RenderGame(Board);
            while (gameRunning)
            {
                Player.Turn();
                UpdateBoard();
                gameRunning &= !CheckForWinner();
                //Bot.Turn();
                //UpdateBoard();
                //gameRunning &= !CheckForWinner();
            }
            EndGameMessage();
        }

        public static Difficulty AskForDifficulty()
        {
            bool isValidSelection;
            Difficulty selectedDifficulty;
            do
            {
                WelcomePage.WriteDifficultyOptions();
                string userInput = Console.ReadLine();
                isValidSelection = Enum.TryParse<Difficulty>(userInput, true, out selectedDifficulty);
                if (!isValidSelection) { Console.WriteLine("Invalid difficulty"); }
            } while (!isValidSelection);
            Console.Clear();
            ExplainRules();
            return selectedDifficulty;
        }

        public static void RenderGame(string[] heaps)
        {
            foreach(string heap in heaps)
            {
                Console.Write(heap);
            }
        }

        public static bool CheckIfValidMove(int amountToRemove, int heapToRemoveFrom)
        {
            int[] remainingStones = { Heaps.Heap1, Heaps.Heap2, Heaps.Heap3 };
            if (remainingStones[heapToRemoveFrom] - amountToRemove < 0) { return false; }
            return true;
        }

        public static bool CheckForWinner()
        {
            if (Heaps.Heap1 == 0 && Heaps.Heap2 == 0 && Heaps.Heap3 == 0) { return true; }
            return false;
        }

        public static void ExplainRules()
        {
            Console.WriteLine("Your turn: ");
            Console.WriteLine("Select a pile by moving with the arrow keys and hitting enter");
            Console.WriteLine("Then enter the amount you want to remove");
            Console.WriteLine();
        }

        public static void EndGameMessage()
        {
            Console.WriteLine("Game Over");
            Console.WriteLine($"Congrats, ! You beat");
            Console.WriteLine("");
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
            for (int i = 0; i < heaps.Length; i++)
            {
                if (i == selectedHeap)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write(heaps[i]);
                }
                else
                {
                    Console.ResetColor();
                    Console.Write(heaps[i]);
                }
            }
        }

        public static void UpdateBoard()
        {
            Board = new string[]{ $"  |_{Heaps.Heap1}_|   ", $"  |_{Heaps.Heap2}_|   ", $"  |_{Heaps.Heap3}_|    " };
            RenderGame(Board);
        }
    }
}

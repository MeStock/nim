using System;
namespace nim
{
    public class WelcomePage
    {
        public static void WriteBanner()
        {
            Console.Write(
".__   __.     __     .___  ___. \n" +
"|  \\ |  |    |  |    |   \\/   | \n" +
"|   \\|  |    |  |    |  \\  /  | \n" +
"|  . `  |    |  |    |  |\\/|  | \n" +
"|  |\\   |    |  |    |  |  |  | \n" +
"|__| \\__|    |__|    |__|  |__| \n"
                );
        }

        public static void StartWithRules()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Welcome to Nim!");
            Console.WriteLine("A Mathematical game where two users take turns removing stones from piles");
            Console.WriteLine();
            Console.WriteLine("There are only a few rules:");
            Console.WriteLine("     -you must remove at least one stone on each turn");
            Console.WriteLine("     -you may remove more than one stone as long as they are from the same pile");
            Console.WriteLine("     -the player who removes the last stone wins!");
            Console.WriteLine();
            Console.WriteLine("Happy Nimming!");

        }
    }
}

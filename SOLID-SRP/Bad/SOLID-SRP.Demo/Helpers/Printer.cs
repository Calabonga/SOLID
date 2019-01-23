using System;
using System.Collections.Generic;

namespace SOLID_SRP.Demo.Helpers
{
    public static class Printer
    {
        public static void Print(string message)
        {
            Console.WriteLine(message);
        }

        public static void Print<T>(IEnumerable<T> items, Func<T, string> predicate)
        {
            foreach (var item in items)
            {
                Console.WriteLine(predicate.Invoke(item), item);
            }
        }

        public static void PrintError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"ERROR: {message}");
            Console.ResetColor();
        }

        public static void PrintInfo(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"INFO: {message}");
            Console.ResetColor();
        }
    }
}

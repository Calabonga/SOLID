using System;
using System.Collections.Generic;

namespace SOLID_SRP.Demo.Infrastructure.Helpers
{
    /// <summary>
    /// Logger emulator
    /// </summary>
    public static class Logger
    {
        public static void Print(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Console write
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="predicate"></param>
        public static void Print<T>(IEnumerable<T> items, Func<T, string> predicate)
        {
            foreach (var item in items)
            {
                Console.WriteLine(predicate.Invoke(item), item);
            }
        }

        /// <summary>
        /// Console write red color
        /// </summary>
        /// <param name="message"></param>
        public static void LogError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"ERROR: {message}");
            Console.ResetColor();
        }

        /// <summary>
        /// Console write red error
        /// </summary>
        /// <param name="exception"></param>
        public static void LogError(Exception exception)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"ERROR: {ExceptionHelper.GetMessages(exception)}");
            Console.ResetColor();
        }

        /// <summary>
        /// Console write blue color
        /// </summary>
        /// <param name="message"></param>
        public static void LogInfo(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"INFO: {message}");
            Console.ResetColor();
        }
    }
}

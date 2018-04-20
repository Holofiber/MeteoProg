using System;

namespace BussinesLogic.Logger
{
    public class ConsoleLogger : ILogger
    {
        public  void Info(string message = "")
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{DateTime.Now:hh:mm:ss} | INFO | {message}");
        }

        public  void Warning(string message = "")
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{DateTime.Now:hh:mm:ss} | WARN | {message}");
        }

        public  void Error(string message = "")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{DateTime.Now:hh:mm:ss} | ERROR | {message}");
        }
    }
}

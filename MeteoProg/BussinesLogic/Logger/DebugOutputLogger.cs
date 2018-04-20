using System;
using System.Diagnostics;

namespace BussinesLogic.Logger
{
    public class DebugOutputLogger : ILogger
    {
        public void Info(string message="")
        {
            Debug.WriteLine($"{DateTime.Now:hh:mm:ss} | INFO | {message}");
        }

        public void Warning(string message = "")
        {
            Debug.WriteLine($"{DateTime.Now:hh:mm:ss} | WARN | {message}");
        }

        public void Error(string message = "")
        {
            Debug.WriteLine($"{DateTime.Now:hh:mm:ss} | ERROR | {message}");
        }
    }
}
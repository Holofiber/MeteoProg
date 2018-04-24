using System;
using System.Configuration;
using System.IO;

namespace BussinesLogic.Loggers
{
    public class FileLogger : ILogger
    {
        readonly string logfilename = ConfigurationManager.AppSettings["loggerFileName"];

        public void Info(string message = "")
        {
            File.AppendAllText(logfilename, $"{ Environment.NewLine}{DateTime.Now:hh:mm:ss} | INFO  | {message}");
        }

        public void Warning(string message = "")
        {
            File.AppendAllText(logfilename, $"{Environment.NewLine}{DateTime.Now:hh:mm:ss} | WARN  | {message}");
        }

        public void Error(string message = "")
        {
            File.AppendAllText(logfilename, $"{Environment.NewLine}{DateTime.Now:hh:mm:ss} | ERROR | {message}");
        }
    }
}
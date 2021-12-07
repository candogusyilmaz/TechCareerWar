using System;

using TechCareerWar.Core.Logger.Abstract;

namespace TechCareerWar.ConsoleApp
{
    internal class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }

        public void LogError(string message)
        {
            Console.WriteLine($"ERR: {message}");
        }
    }
}

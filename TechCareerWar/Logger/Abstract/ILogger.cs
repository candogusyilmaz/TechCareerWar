using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCareerWar.Logger
{
    internal interface ILogger
    {
        void Log(string message);
        void LogError(string message);
    }
}

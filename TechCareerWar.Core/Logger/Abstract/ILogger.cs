namespace TechCareerWar.Core.Logger.Abstract
{
    public interface ILogger
    {
        void Log(string message);
        void LogError(string message);
    }
}

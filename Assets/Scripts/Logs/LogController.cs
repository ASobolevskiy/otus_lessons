namespace Assets.Scripts.Logs
{
    public sealed class LogController
    {
        public LogController(ILogger logger)
        {
            logger.Log("LogController");
        }
    }
}

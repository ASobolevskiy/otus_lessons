using UnityEngine;

namespace Assets.Scripts.Logs
{
    public sealed class Logger : ILogger
    {
        public Logger()
        {
            Debug.LogError("VAR");
        }

        public void Log(string message)
        {
            Debug.Log(message);
        }
    }
}

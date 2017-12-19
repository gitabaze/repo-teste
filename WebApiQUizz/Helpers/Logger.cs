using System.Diagnostics;

namespace WebApiQUizz.Helpers
{
    public class Logger : ILogger
    {
        public void Write(string message, params object[] args)
        {
            Debug.WriteLine(message, args);
        }
    }
}
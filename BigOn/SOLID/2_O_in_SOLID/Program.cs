using System;

namespace _2_O_in_SOLID
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LogManager log = new LogManager();
            var logger = new EmailLogger();

            log.Debug(logger,"Hello");
        }
    }


    class FileLogger : ILogger
    {
        private readonly string filePath;

        public FileLogger(string filePath)
        {
            this.filePath = filePath;
        }
        public void Log(string data)
        {
            throw new NotImplementedException();
        }
    }

    class DbLogger : ILogger
    {
        public void Log(string data)
        {
            throw new NotImplementedException();
        }
    }

    class EmailLogger : ILogger
    {
        public void Log(string data)
        {
            throw new NotImplementedException();
        }
    }

    class SmsLogger : ILogger
    {
        public void Log(string data)
        {
            throw new NotImplementedException();
        }
    }

    public interface ILogger
    {
        void Log(string data);
    }

    class LogManager
    {
        public void Debug(ILogger logger, string data)
        {
            logger.Log(data);
        }
    }
}

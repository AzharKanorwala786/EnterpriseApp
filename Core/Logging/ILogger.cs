using System;

namespace Core.Logging
{
  public interface ILogger
    {
        //Logging
        void Log(string message);
        void Log(Exception ex);
    }
}

using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Core.GeneralHelper
{
    public interface ILoggingService
    {
        void LogInformation(string message);
        void LogError(string message, Exception exception);
    }

    public class LoggingService : ILoggingService
    {
        public void LogError(string message, Exception exception)
        {
           Log.Error(message, exception);    
        }

        public void LogInformation(string message)
        {
            Log.Information(message);
        }
    }
}

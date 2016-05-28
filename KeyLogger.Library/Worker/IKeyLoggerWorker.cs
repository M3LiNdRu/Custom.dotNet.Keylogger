using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyLogger.Library.Worker
{
    public interface IKeyLoggerWorker
    {
        void DoWork(object appender);
        void RequestStop();
    }
}

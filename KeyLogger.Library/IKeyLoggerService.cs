using KeyLogger.Library.Appenders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyLogger.Library
{
    public interface IKeyLoggerService
    {
        IOutputAppender SetOutputMode { set; }
        void Start();
        void Stop();
    }
}

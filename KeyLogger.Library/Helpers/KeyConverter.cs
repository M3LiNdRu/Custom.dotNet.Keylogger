using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyLogger.Library.Helpers
{
    public class KeyConverter
    {
        /// <summary>
        /// Convert KeyCode to char. Return char MinValue if it can´t convert the value
        /// </summary>
        /// <param name="key"></param>
        /// <returns>char</returns>
        public static char KeyCodeToChar(int key)
        {
            KeysConverter kc = new KeysConverter();
            try
            {
                char keyChar = (char)kc.ConvertTo(key, typeof(char));
                return keyChar;

            } catch (Exception ex)
            {
                return char.MinValue;
            }
            
        }

        public static char KeyCodeToChar2(int key)
        {
            KeysConverter kc = new KeysConverter();
            try
            {
                string keyChar = kc.ConvertToString(key);
                return keyChar.FirstOrDefault();

            }
            catch (Exception ex)
            {
                return char.MinValue;
            }

        }
    }
}

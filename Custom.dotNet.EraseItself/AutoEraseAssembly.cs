using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.dotNet.EraseItself
{
    public static class AutoEraseAssembly
    {
        public static void ByCommandLine(string execPath)
        {
            ProcessStartInfo Info = new ProcessStartInfo();
            Info.Arguments = string.Format("/C choice /C Y /N /D Y /T 3 & Del {0}", execPath);
            Info.WindowStyle = ProcessWindowStyle.Hidden;
            Info.CreateNoWindow = true;
            Info.FileName = "cmd.exe";
            Process.Start(Info);
        }

        public static void OnReboot()
        {
            throw new NotImplementedException();
        }
    }
}

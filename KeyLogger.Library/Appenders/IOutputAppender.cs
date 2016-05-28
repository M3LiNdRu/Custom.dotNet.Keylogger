using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyLogger.Library.Appenders
{
    public interface IOutputAppender
    {
        void SaveToBuffer(char key);
        void FinalPush();
    }
}

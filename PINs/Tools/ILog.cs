using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PINs.Tools
{
    /// <summary>
    /// interface log
    /// can be implemented to different concrete log class, physical File, showing , database ,XML file ....
    /// </summary>
    public interface ILog
    {
        void Info(string infoText);
        void Debug(string debugText);
        void Warn(string warmText);
        void Error(string errorText, Exception exception);

        void SetObject(object obj);
    }
    
}

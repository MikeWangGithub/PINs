using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PINs.Tools
{
    /// <summary>
    /// ClearData interface .facilitate extends to deletefile or delete data in table in Database
    /// </summary>
    public interface IClearData
    {
        /// <summary>
        /// Info : Physical FileName or ConnectionString of database
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        bool Clear(string Info);
        /// <summary>
        /// Set Object which will be stored with digits
        /// </summary>
        /// <param name="ts"></param>
        void SetClearObject(ISet<int> ts);

    }
}

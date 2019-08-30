using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PINs.Tools
{
    /// <summary>
    /// SaveData interface .facilitate extends to FileSave or DatabaseSave
    /// </summary>
    public interface ISaveData<T>
    {
        /// <summary>
        /// Info : Physical FileName or ConnectionString of database
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        bool Save(string Info);
        void SetSaveObject(HashSet<T> ts);
        void SetSaveObject(SortedSet<T> ts);

    }
}

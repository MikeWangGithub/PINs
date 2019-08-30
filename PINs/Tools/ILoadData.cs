using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PINs.Tools
{
    /// <summary>
    /// LoadData interface .facilitate extends to FileLoad or DatabaseLoad
    /// </summary>
    public interface ILoadData
    {
        /// <summary>
        /// Info : Physical FileName or ConnectionString of database
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        bool Load(string Info);
        void SetLoadObject(HashSet<int> ts);
        void SetLoadObject(SortedSet<int> ts);
    }
}

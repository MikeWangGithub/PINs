using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PINs.Tools
{
    interface IDataInitial
    {
        /// <summary>
        /// Data Initital Info
        /// </summary>
        /// <param name="Info">FileName / DataBase ConnectionString /....</param>
        /// <returns>true:dataset is created;false: not created</returns>
        bool IsInitial(string Info);
        void SetInitialObject(ISet<int> ts);
    }
}

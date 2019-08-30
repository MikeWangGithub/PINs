using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PINs.Algorithm
{
    /// <summary>
    /// Encapsulate Random Functions
    /// </summary>
    public class PINRandom
    {
        /// <summary>
        /// Static object
        /// </summary>
        private static System.Random ran = new System.Random((int)System.DateTime.Now.Ticks);
        /// <summary>
        /// Both max and min must be positive number and max must be bigger than min
        /// Otherwise return -1
        /// </summary>
        /// <param name="max">A positive number</param>
        /// <param name="min">A positive number</param>
        /// <returns>a randomo integer </returns>
        public static int GetRandomDigit(int min,int max)
        {
            int rtn = -1;
            if( (min>0) || (max>0) || (min <= max))
            {
                rtn = ran.Next(min, max + 1);
            }
            return rtn;
        }
    }
}

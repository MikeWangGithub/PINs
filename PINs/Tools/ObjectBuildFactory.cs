using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PINs.Tools
{
    /// <summary>
    /// DIP Class
    /// </summary>
    /// <typeparam name="T">generic class</typeparam>
    public class ObjectBuildFactory<T>
    {
        /// <summary>
        /// Create concrete class by ClassName
        /// </summary>
        /// <param name="key">fullClasName</param>
        /// <returns></returns>
        public static T Instance(string key)
        {
            Type obj = Type.GetType(key);
            if (obj == null) return default(T);

            T factory = (T)obj.Assembly.CreateInstance(obj.FullName);

            return factory;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PINs.Tools
{
    public class ObjectBuildFactory<T>
    {
        public static T Instance(string key)
        {
            Type obj = Type.GetType(key);
            if (obj == null) return default(T);

            T factory = (T)obj.Assembly.CreateInstance(obj.FullName);

            return factory;
        }
    }
}

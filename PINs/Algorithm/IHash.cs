using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PINs.Algorithm
{
    public interface IHash<T>
    {

        bool Insert(T t);
        bool Delete(T t);

        bool Contains(T t);

        int Length { get; }
    }
}

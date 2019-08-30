using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PINs.Algorithm
{
    /// <summary>
    /// Hash Object Interface which save any type's object in the HashSet
    /// </summary>
    /// <typeparam name="T">Node Type</typeparam>
    public interface IHash<T>
    {

        /// <summary>
        /// Add a node in hashset
        /// </summary>
        /// <param name="t">Node Type</param>
        /// <returns>Operation is sucessful,return true otherwise false</returns>
        bool Insert(T t);
        /// <summary>
        /// Delete a node in hashset
        /// </summary>
        /// <param name="t">Node Type</param>
        /// <returns>Operation is sucessful,return true otherwise false</returns>
        bool Delete(T t);
        /// <summary>
        /// judage if hashset contain a PIN
        /// </summary>
        /// <param name="t"></param>
        /// <returns>If hashset contains the PIN(the value of t),return true otherwise false</returns>
        bool Contains(T t);

        /// <summary>
        /// the quantity of hashset's nodes
        /// </summary>
        int Length { get; }
    }
}

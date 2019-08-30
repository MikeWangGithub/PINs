using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PINs.Algorithm
{
    /// <summary>
    /// BinaryTree Interface which save any type's object in the tree
    /// </summary>
    /// <typeparam name="T">Node Type</typeparam>
    public interface IBinaryTree<T> 
    {
        /// <summary>
        /// Add a node in the tree
        /// </summary>
        /// <param name="t">Node Type</param>
        /// <returns>Operation is sucessful,return true otherwise false</returns>
        bool Insert(T t);
        /// <summary>
        /// Delete a node in the tree
        /// </summary>
        /// <param name="t">Node Type</param>
        /// <returns>Operation is sucessful,return true otherwise false</returns>
        bool Delete(T t);
        /// <summary>
        /// judage if the tree contain a PIN
        /// </summary>
        /// <param name="t"></param>
        /// <returns>If The tree contains the PIN(the value of t),return true otherwise false</returns>
        bool Contains(T t);

        /// <summary>
        /// the quantity of the tree's nodes
        /// </summary>
        int Length { get; }

    }
}

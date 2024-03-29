﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PINs.Algorithm
{
    /// <summary>
    /// BinaryTree / HashTable Interface which save any type's object in the set
    /// In this program the type will be saved in the ISet is Integer
    /// </summary>
    /// <typeparam name="T">Node Type</typeparam>
    public interface ISet<T> 
    {
        /// <summary>
        /// Add a node in the set
        /// </summary>
        /// <param name="t">Node Type</param>
        /// <returns>Operation is sucessful,return true otherwise false</returns>
        bool Insert(T t);
        /// <summary>
        /// Delete a node in the set
        /// </summary>
        /// <param name="t">Node Type</param>
        /// <returns>Operation is sucessful,return true otherwise false</returns>
        bool Delete(T t);
        /// <summary>
        /// judage if the set contain a PIN
        /// </summary>
        /// <param name="t"></param>
        /// <returns>If The tree contains the PIN(the value of t),return true otherwise false</returns>
        bool Contains(T t);
        /// <summary>
        /// Clear all nodes.
        /// </summary>
         void Clear(string inof);

        /// <summary>
        /// the quantity of the set's nodes
        /// </summary>
        int Length { get; }

        /// <summary>
        /// For loop 
        /// </summary>
        IEnumerable<T> Items { get; }
        /// <summary>
        /// Get value by Index of node
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        T GetValue(int index);
        /// <summary>
        /// Save data to somewhere.a physical file / a database / cloudy storage ...
        /// </summary>
        /// <param name="info">FileName/ConnectionString/cloudypath/...</param>
        /// <returns></returns>
        bool Save(string info);

        /// <summary>
        /// Load data from somewhere.a physical file / a database / cloudy storage ...
        /// </summary>
        /// <param name="info">FileName/ConnectionString/cloudypath/...</param>
        /// <returns></returns>
        bool Load(string info);
        /// <summary>
        /// Judge if data initial
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool IsInitial(string info);

    }
}

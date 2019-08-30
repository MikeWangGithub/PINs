using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace PINs.Tools
{
    /// <summary>
    /// Thread Name Set
    /// </summary>
    public enum PINThreadName { GetNumber = 1, DigitInitial = 2 }
    /// <summary>
    /// AlgorithmType Set
    /// </summary>
    public enum AlgorithmType { RedBlackTree = 1, HashSet = 2 }

    /// <summary>
    /// Thread Parameter for Digit Initial
    /// </summary>
    public class DigitInitialParameter : ICloneable {

        /// <summary>
        /// Delegate function for refresh quantity on the mainform
        /// </summary>
        private SafeCallDelegate _RefreshQuantityFunction;
        public SafeCallDelegate RefreshQuantityFunction
        {
            get { return _RefreshQuantityFunction; }
        }
        public void SetRefreshQuantityFunction(SafeCallDelegate value)
        {
            _RefreshQuantityFunction = value;
        }
        /// <summary>
        /// Copy object, high effective than create object
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }


   
}

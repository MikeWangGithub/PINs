using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace PINs.Tools
{
    public enum PINThreadName { GetNumber = 1, DigitInitial = 2 }
    public enum AlgorithmType { RedBlackTree = 1, HashSet = 2 }

    public class DigitInitialParameter : ICloneable {

        private SafeCallDelegate _RefreshQuantityFunction;
        public SafeCallDelegate RefreshQuantityFunction
        {
            get { return _RefreshQuantityFunction; }
        }
        public void SetRefreshQuantityFunction(SafeCallDelegate value)
        {
            _RefreshQuantityFunction = value;
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }


   
}

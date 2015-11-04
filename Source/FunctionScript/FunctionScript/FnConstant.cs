using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunctionScript
{
    /// <summary>
    /// Represents an FnScript Constant
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class FnConstant<T> : FnObject<T>
    {
        public readonly T Value;

        public FnConstant(T value)
        {
            Value = value;
        }

        internal override bool IsCachable()
        {
            return true;
        }

        public override T GetValue()
        {
            return Value;
        }

        public override object GetValueAsObject()
        {
            return (object)Value;
        }
    }
}

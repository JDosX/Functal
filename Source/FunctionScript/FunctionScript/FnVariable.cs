using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunctionScript
{
    public class FnVariable<T> : FnObject<T>
    {
        //FnVariable will also need a bit to link to the related FnMethod it gets
        //its value from, which can be null if it isn't linked to anything

        public T Value;

        public FnVariable(T value)
        {
            Value = value;
        }

        internal override bool IsCachable()
        {
            return false;
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

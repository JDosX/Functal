using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FnScriptTesting
{
    public abstract class TemplateLocal
    {
    }

    public class TemplateLocal_Return<T> : TemplateLocal
    {
        public T data;

        public void Set (T input)
        {
            data = input;
        }

        public T Get()
        {
            return data;
        }
    }
}

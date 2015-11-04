using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunctionScript
{
    public abstract class FnObject
    {
        /// <summary>
        /// Returns the data type of the variable wrapped by this FnObject
        /// </summary>
        /// <returns></returns>
        public abstract Type GetWrappedObjectType();
        /// <summary>
        /// Gets the value of the variable wrapped by this FnObject as an Object
        /// </summary>
        /// <returns></returns>
        public abstract Object GetValueAsObject();

        internal abstract FnObject CreateFnVariableWithSameType();
        internal abstract FnObject CreateFnIfWithSameType(FnObject<bool> condition, FnObject trueArg, FnObject falseArg);
        
        /// <summary>
        /// Checks the execution tree stemming from this FnObject and caches all acceptable nodes
        /// </summary>
        internal abstract List<FnObject> CheckAndCache();
        /// <summary>
        /// Determines if this FnObject is cachable
        /// </summary>
        /// <returns></returns>
        internal abstract Boolean IsCachable();
    }


    public abstract class FnObject<T> : FnObject
    {
        #region Abstract Methods
        public abstract T GetValue();
        #endregion

        #region Methods
        /// <summary>
        /// Returns the data type of the object the FnObject is wrapping
        /// </summary>
        /// <returns></returns>
        public override Type GetWrappedObjectType()
        {
            return typeof(T);
        }

        #region CreateFnObjectWithSameType methods
        internal override FnObject CreateFnVariableWithSameType()
        {
            return new FnVariable<T>(default(T));
        }
        /// <summary>
        /// Createa a conditional FnObject with the same return type as the one the method is called from. Is useful as the arguments for a conditional FnObject should always be created before the conditional
        /// </summary>
        /// <param name="methodParameters"></param>
        /// <returns></returns>
        internal override FnObject  CreateFnIfWithSameType(FnObject<bool> condition, FnObject trueArg, FnObject falseArg)
        {
            return new FnIf<T>(condition, trueArg, falseArg);
        }
        #endregion

        internal override List<FnObject> CheckAndCache()
        {
            //For the moment
            return null;
        }
        #endregion
    }

    [System.AttributeUsage(AttributeTargets.Field)]
    public class FnArg : System.Attribute
    {
        public FnArg()
        {
        }
    }

    //OLD ISCACHABLE METHOD
    /*/// <summary>
    /// Determines if the FnObject is Cachable
    /// </summary>
    /// <returns></returns>
    public Boolean IsCachable()
    {
        if (CompileFlags.Contains(FnScriptResources.CompileFlags.DO_NOT_CACHE))
        {
            return false;
        }
        else if (_MethodParameters != null)
        {
            for (Int32 i = 0; i < _MethodParameters.Count; i++)
            {
                if (!_MethodParameters[i].IsCachable())
                {
                    return false;
                }
            }
        }
        return true;
    }*/



    //OLD CHECK AND CACHE METHOD

    /*/// <summary>
    /// Caches the execution tree starting from this FnObject node, it returns a list of all the nodes that were removed during the caching process
    /// </summary>
    public List<FnObject> CheckAndCache()
    {
        List<FnObject> removedObjects = new List<FnObject>();

        Boolean cachable = true;

        if (_MethodParameters != null)
        {
            for (int i = 0; i < _MethodParameters.Count; i++)
            {
                removedObjects.AddRange(_MethodParameters[i].CheckAndCache());

                if ((_MethodParameters[i].CompileFlags != null && _MethodParameters[i].CompileFlags.Contains(FnScriptResources.CompileFlags.DO_NOT_CACHE)) || !_MethodParameters[i].IsVariable())
                {
                    cachable = false;
                }
            }
        }

        if ((CompileFlags == null || !CompileFlags.Contains(FnScriptResources.CompileFlags.DO_NOT_CACHE)) && cachable == true)
        {
            GetValue();

            EvalMethod = null;

            //record the FnObjects which are being removed from the expression so they can be removed in the master list
            if (_MethodParameters != null)
            {
                removedObjects.AddRange(_MethodParameters);
            }

            _MethodParameters = null;
        }

        return removedObjects;
    }*/


    //OLD GETVALUE METHOD
    /*/// <summary>
    /// Returns the output of the FnObject if it exists. If not, it executes the bound method and then returns the value
    /// </summary>
    /// <returns></returns>
    public T GetValue()
    {
        //if we have already executed the bound method, return the result only.
        //if not, execute the method, store the output in ObjectValue, return ObjectValue

        if (_HasExecuted == false)
        {
            if (EvalMethod != null) //if it's a method
            {
                ObjectValue = EvalMethod(_MethodParameters);     //Execute bound method and store the result
            }
            else                    //it's a condition
            {
                if ((_MethodParameters[0] as FnObject<Boolean>).GetValue() == true)
                {
                    ObjectValue = (_MethodParameters[1] as FnObject<T>).GetValue();
                }
                else
                {
                    ObjectValue = (_MethodParameters[2] as FnObject<T>).GetValue();
                }
            }
            _HasExecuted = true;
        }

        return ObjectValue;
    }*/
}

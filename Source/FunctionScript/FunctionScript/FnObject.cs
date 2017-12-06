using System;

namespace FunctionScript {

  /// <summary>
  /// Represents a construct of the FunctionScript language.
  /// </summary>
  public abstract class FnObject {
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
    internal abstract FnObject CheckAndCache();
    /// <summary>
    /// Determines if this FnObject is cachable
    /// </summary>
    /// <returns></returns>
    internal abstract Boolean IsCachable();
  }


  public abstract class FnObject<T> : FnObject {
    #region Abstract Methods
    public abstract T GetValue();
    #endregion

    #region Methods
    /// <summary>
    /// Returns the data type of the object the FnObject is wrapping
    /// </summary>
    /// <returns></returns>
    public override Type GetWrappedObjectType() {
      return typeof(T);
    }

    #region CreateFnObjectWithSameType methods
    internal override FnObject CreateFnVariableWithSameType() {
      return new FnVariable<T>(default(T));
    }
    /// <summary>
    /// Createa a conditional FnObject with the same return type as the one the method is called from. Is useful as the arguments for a conditional FnObject should always be created before the conditional
    /// </summary>
    /// <param name="methodParameters"></param>
    /// <returns></returns>
    internal override FnObject CreateFnIfWithSameType(FnObject<bool> condition, FnObject trueArg, FnObject falseArg) {
      return new FnIf<T>(condition, trueArg, falseArg);
    }
    #endregion

    /// <summary>
    /// Optimises the execution tree that branches out from this node.
    /// Returns a new execution tree root node.
    /// </summary>
    //internal override FnObject CheckAndCache()
    //{
    //    Boolean cachable = true;

    //    if (IsCachable())
    //    {

    //    }



    //    Boolean cachable = true;

    //    if (_MethodParameters != null)
    //    {
    //        for (int i = 0; i < _MethodParameters.Count; i++)
    //        {
    //            removedObjects.AddRange(_MethodParameters[i].CheckAndCache());

    //            if ((_MethodParameters[i].CompileFlags != null && _MethodParameters[i].CompileFlags.Contains(FnScriptResources.CompileFlags.DO_NOT_CACHE)) || !_MethodParameters[i].IsVariable())
    //            {
    //                cachable = false;
    //            }
    //        }
    //    }

    //    if ((CompileFlags == null || !CompileFlags.Contains(FnScriptResources.CompileFlags.DO_NOT_CACHE)) && cachable == true)
    //    {
    //        GetValue();

    //        EvalMethod = null;

    //        //record the FnObjects which are being removed from the expression so they can be removed in the master list
    //        if (_MethodParameters != null)
    //        {
    //            removedObjects.AddRange(_MethodParameters);
    //        }

    //        _MethodParameters = null;
    //    }

    //    return removedObjects;
    //}
    #endregion
  }

  [System.AttributeUsage(AttributeTargets.Field)]
  public class FnArg : System.Attribute {
    public FnArg() {
    }
  }
}

using System;

namespace FunctionScript {

  /// <summary>
  /// Represents a FunctionScript language construct.
  /// </summary>
  public abstract class FnObject {
    /// <summary>
    /// Returns the data type wrapped by this FnObject.
    /// </summary>
    public abstract Type GetWrappedObjectType();

    /// <summary>
    /// Gets the value of the data wrapped by this FnObject as an <see cref="object"/>.
    /// </summary>
    public abstract Object GetValueAsObject();

    internal abstract FnObject CreateFnVariableWithSameType();

    internal abstract FnObject CreateFnIfWithSameType(FnObject<bool> condition, FnObject trueArg, FnObject falseArg);

    /// <summary>
    /// Optimises the execution tree stemming from this FnObject.
    /// </summary>
    /// <remarks>
    /// The optimisations performed will vary depending on the version of FunctionScript. In this version, the following
    /// optimisations are performed:
    /// <list type="bullet">
    ///   <item>
    ///   Collapse any nodes in the execution tree that are immutable. That is, any nodes that can't be mutated (such as
    ///   constants), and any nodes that do not have side-effects (such as a pure function).
    ///   </item>
    /// </list>
    /// </remarks>
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

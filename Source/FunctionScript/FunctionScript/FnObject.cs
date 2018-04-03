using System;

namespace FunctionScript {

  /// <summary>
  /// Represents a FunctionScript language construct.
  /// </summary>
  public abstract class FnObject {
    /// <summary>
    /// Returns the data type wrapped by this <see cref="FnObject"/>.
    /// </summary>
    public abstract Type GetWrappedObjectType();

    /// <summary>
    /// Gets the value of the data wrapped by this FnObject as an <see cref="object"/>.
    /// </summary>
    public abstract Object GetValueAsObject();

    /// <summary>
    /// Creates an <see cref="FnVariable"/> with the same wrapped type as this <see cref="FnObject"/>.
    /// </summary>
    internal abstract FnObject CreateFnVariableWithSameType();

    /// <summary>
    /// Creates an <see cref="FnIf"/> object with the same wrapped type as this <see cref="FnObject"/>.
    /// </summary>
    /// <param name="condition">The conditional for the <see cref="FnIf"/>.</param>
    /// <param name="trueArg">The execution tree to execute if <see cref="condition"/> returns true.</param>
    /// <param name="falseArg">The execution tree to execute if <see cref="condition"/> returns false.</param>
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
    /// Determines if this <see cref="FnObject"/> is cachable.
    /// </summary>
    /// <returns>True if the FnObject is Cachable, False if not.</returns>
    internal abstract Boolean IsCachable();
  }

  /// <summary>
  /// Represent a FunctionScript language construct.
  /// </summary>
  /// <typeparam name="T">The type wrapped by the <see cref="FnObject"/>.</typeparam>
  public abstract class FnObject<T> : FnObject {
    #region Abstract Methods
    /// <summary>
    /// Executes the object and returns the contained value.
    /// </summary>
    public abstract T GetValue();
    #endregion

    #region Public Methods
    /// <summary>
    /// Returns the data type wrapped by this FnObject.
    /// </summary>
    public override Type GetWrappedObjectType() {
      return typeof(T);
    }
    #endregion

    #region Internal Methods
    internal override FnObject CreateFnVariableWithSameType() {
      return new FnVariable<T>(default(T));
    }

    internal override FnObject CreateFnIfWithSameType(FnObject<bool> condition, FnObject trueArg, FnObject falseArg) {
      return new FnIf<T>(condition, trueArg, falseArg);
    }
    #endregion
  }
}

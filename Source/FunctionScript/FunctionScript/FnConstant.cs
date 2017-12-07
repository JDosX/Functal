using System;

namespace FunctionScript {
  /// <summary>
  /// Represents a FunctionScript constant.
  /// </summary>
  /// <typeparam name="T">The contained type of the constant.</typeparam>
  public class FnConstant<T> : FnObject<T> {
    /// <summary>
    /// The value of the constant.
    /// </summary>
    public readonly T Value;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="value">The value of the constant.</param>
    public FnConstant(T value) {
      Value = value;
    }

    internal override bool IsCachable() {
      return true;
    }

    /// <summary>
    /// Returns an optimized version of this FnObject.
    /// </summary>
    /// <returns>An optimized version of this FnObject.</returns>
    internal override FnObject CheckAndCache() {
      return this;
    }

    public override T GetValue() {
      return Value;
    }

    public override object GetValueAsObject() {
      return (object)Value;
    }
  }
}

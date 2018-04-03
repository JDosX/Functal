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

    internal override FnObject CheckAndCache() {
      return this;
    }

    /// <summary>
    /// Executes the object and returns the contained value.
    /// </summary>
    public override T GetValue() {
      return Value;
    }

    /// <summary>
    /// Gets the value of the data wrapped by this FnObject as an <see cref="object"/>.
    /// </summary>
    public override object GetValueAsObject() {
      return (object)Value;
    }
  }
}

using System;

namespace FunctionScript {
  /// <summary>
  /// Represents a FunctionScript variable.
  /// </summary>
  public class FnVariable<T> : FnObject<T> {
    /// <summary>
    /// The value this FnVariable wraps.
    /// </summary>
    public T Value;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="value">The value the FnVariable should wrap.</param>
    public FnVariable(T value) {
      Value = value;
    }

    internal override bool IsCachable() {
      return false;
    }

    /// <summary>
    /// Returns an optimized version of this FnObject.
    /// </summary>
    internal override FnObject CheckAndCache() {
      return this;
    }

    /// <summary>
    /// Returns the value wrapped by this object.
    /// </summary>
    /// <returns>The value.</returns>
    public override T GetValue() {
      return Value;
    }

    public override object GetValueAsObject() {
      return (object)Value;
    }
  }
}

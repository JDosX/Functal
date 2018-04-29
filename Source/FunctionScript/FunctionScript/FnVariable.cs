namespace FunctionScript {
  /// <summary>
  /// Represents a FunctionScript variable/parameter.
  /// </summary>
  public class FnVariable<T> : FnObject<T> {
    /// <summary>
    /// The value of the <see cref="FnVariable{T}"/>.
    /// </summary>
    public T Value;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="value">The value of the <see cref="FnVariable{T}"/>.</param>
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
    /// Gets the value of this <see cref="FnVariable{T}"/>.
    /// </summary>
    /// <returns>The value.</returns>
    public override T GetValue() {
      return Value;
    }

    /// <summary>
    /// Gets the value of this <see cref="FnVariable{T}"/> as an <see cref="object"/>.
    /// </summary>
    /// <returns>The value as object.</returns>
    public override object GetValueAsObject() {
      return (object)Value;
    }
  }
}

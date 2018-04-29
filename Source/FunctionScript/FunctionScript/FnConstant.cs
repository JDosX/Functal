namespace FunctionScript {
  /// <summary>
  /// Represents a FunctionScript constant.
  /// </summary>
  /// <typeparam name="T">The contained type of the constant.</typeparam>
  public class FnConstant<T> : FnObject<T> {
    /// <summary>
    /// The value of the <see cref="FnConstant{T}"/>.
    /// </summary>
    public readonly T Value;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="value">The value of the <see cref="FnConstant{T}"/>.</param>
    public FnConstant(T value) {
      Value = value;
    }

    /// <summary>
    /// Gets the value of this <see cref="FnConstant{T}"/>
    /// </summary>
    public override T GetValue() {
      return Value;
    }

    /// <summary>
    /// Gets the value of this <see cref="FnConstant{T}"/> as an <see cref="object"/>.
    /// </summary>
    public override object GetValueAsObject() {
      return (object)Value;
    }

    internal override bool IsCachable() {
      return true;
    }

    internal override FnObject CheckAndCache() {
      return this;
    }
  }
}

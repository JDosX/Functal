namespace Functal {
  /// <summary>
  /// Represents a Functal variable/parameter.
  /// </summary>
  /// <typeparam name="T">The type wrapped by the <see cref="FnVariable{T}"/>.</typeparam>
  public class FnVariable<T> : FnObject<T> {
    /// <summary>
    /// The value of the <see cref="FnVariable{T}"/>.
    /// </summary>
    public T Value;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="value">The initial value of the <see cref="FnVariable{T}"/>.</param>
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
    public override object GetValueAsObject() {
      return (object)Value;
    }
  }
}

using System;

namespace FunctionScript {
  /// <summary>
  /// A FunctionScript conditional.
  /// </summary>
  internal class FnIf<T> : FnObject<T> {
    /// <summary>
    /// The conditional.
    /// </summary>
    private FnObject<bool> Condition;

    /// <summary>
    /// This FnObject is executed in the event that Conditon evaluates to true.
    /// </summary>
    private FnObject<T> TrueArg;

    /// <summary>
    /// This FnObject is executed in the event that Condition evaluates to false.
    /// </summary>
    private FnObject<T> FalseArg;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="condition">
    /// A boolean expression which determines if trueArg or falseArg is executed and returned.
    /// </param>
    /// <param name="trueArg">An expression whose value is returned if condition returns true.</param>
    /// <param name="falseArg">An expression whose value is returned if condition returns false.</param>
    internal FnIf(FnObject<bool> condition, FnObject trueArg, FnObject falseArg) {
      Condition = condition;
      TrueArg = trueArg as FnObject<T>;
      FalseArg = falseArg as FnObject<T>;
    }

    internal override bool IsCachable() {
      if (Condition.IsCachable()) {
        bool condition = Condition.GetValue();
        return (condition && TrueArg.IsCachable()) || (!condition && FalseArg.IsCachable());
      }

      return false;
    }

    internal override FnObject CheckAndCache() {
      // Optimize child FnObjects.
      Condition = Condition.CheckAndCache() as FnObject<Boolean>;
      TrueArg   =   TrueArg.CheckAndCache() as FnObject<T>;
      FalseArg  =  FalseArg.CheckAndCache() as FnObject<T>;

      // Optimize this node.
      if (IsCachable()) {
        return new FnConstant<T>(GetValue());
      }

      // Can't optimize.
      return this;
    }

    /// <summary>
    /// Executes the object and returns the contained value.
    /// </summary>
    public override T GetValue() {
      if (Condition.GetValue()) {
        return TrueArg.GetValue();
      }

      return FalseArg.GetValue();
    }

    /// <summary>
    /// Gets the value of the data wrapped by this FnObject as an <see cref="object"/>.
    /// </summary>
    public override object GetValueAsObject() {
      if (Condition.GetValue()) {
        return TrueArg.GetValueAsObject();
      }

      return FalseArg.GetValueAsObject();
    }
  }
}

using System;
using System.Collections.Generic;

namespace FunctionScript {
  /// <summary>
  /// The generic interface for a function pointer.
  /// </summary>
  internal interface FnFunctionPointer {
    /// <summary>
    /// Gets the return type of the contained function reference
    /// </summary>
    /// <returns></returns>
    Type GetTypeOfObject();

    /// <summary>
    /// Creates an FnObject using the contained function reference
    /// </summary>
    /// <param name="functionParameters">The parameters to use in the function call.</param>
    /// <param name="ghostParameters">The ghost parameters that can be accessed from the function implementation without declaring them.</param>
    /// <param name="isImmutableExecute">
    /// The <see cref="FnVariable"/> used to determine if the function wil be immutably executed.
    /// </param>
    FnObject CreateObjectWithPointer(List<FnObject> functionParameters, Dictionary<String, FnObject> parameters, FnVariable<Boolean> isPreExecute);

    Type[] GetFunctionTypeArray();
  }

  /// <summary>
  /// Stores a reference to a function with a list of FnObjects as the specified arguments, and can be used to create an
  /// FnObject containing the function reference.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  internal class FnFunctionPointer<T> : FnFunctionPointer {
    /// <summary>
    /// The function reference this <see cref="FnFunctionPointer"/> wraps.
    /// </summary>
    public readonly FnFunction<T> Target;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="target">The function reference to wrap.</param>
    public FnFunctionPointer(FnFunction<T> target) {
      // I shouldn't need to worry about creating a blank verion of the FnFunction, unless
      // I want to ensure the function provided isn't lugging unneccessary data around (potential security flaw).
      Target = target;
    }

    /// <summary>
    /// Gets the return type of the contained function reference.
    /// </summary>
    public Type GetTypeOfObject() {
      return typeof(T);
    }

    /// <summary>
    /// Creates an FnObject using the contained function reference
    /// </summary>
    /// <param name="functionParameters">The parameters to use in the function call.</param>
    /// <param name="ghostParameters">The ghost parameters that can be accessed from the function implementation without declaring them.</param>
    /// <param name="isImmutableExecute">
    /// The <see cref="FnVariable"/> used to determine if the function wil be immutably executed.
    /// </param>
    public FnObject CreateObjectWithPointer(List<FnObject> functionParameters, Dictionary<String, FnObject> parameters, FnVariable<Boolean> isImmutableExecute) {
      return Target.CreateNewFunction(functionParameters, parameters, isImmutableExecute);
    }

    public Type[] GetFunctionTypeArray() {
      return Target.ArgumentTypes;
    }
  }
}

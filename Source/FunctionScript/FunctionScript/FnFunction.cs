using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FunctionScript {
  /// <summary>
  /// <para>
  /// <see cref="Attribute"/> tag for identifying if an <see cref="FnObject"/> is an
  /// <see cref="FnFunction{T}"/> argument.
  /// </para>
  /// <para>
  /// The order in which <see cref="FnArg"/>s are declared is the order in which they must
  /// be provided when calling the function from a FunctionScript expression.
  /// </para>
  /// </summary>
  [System.AttributeUsage(AttributeTargets.Field)]
  public class FnArg : Attribute { }

  /// <summary>
  /// Represents a FunctionScript function.
  /// </summary>
  /// <typeparam name="T">
  /// The type return by the <see cref="FnFunction{T}"/> when executed.
  /// </typeparam>
  public abstract class FnFunction<T> : FnObject<T> {
    #region Nested Data Types
    /// <summary>
    /// Flags which can be used to correctly compile an <see cref="FnFunction{T}"/> into an
    /// <see cref="FnScriptExpression"/>.
    /// </summary>
    public enum CompileFlags {
      /// <summary>
      /// Sets the <see cref="FnFunction{T}"/> as un-cachable. Use this if the function cannot be
      /// executed immutably.
      /// </summary>
      DO_NOT_CACHE = 0,
      /// <summary>
      /// Marks the <see cref="FnFunction{T}"/> as an implicit type conversion. An
      /// <see cref="FnFunction{T}"/> with this flag can only take one function argument.
      /// </summary>
      IMPLICIT_CONVERSION,
    }
    #endregion

    #region Fields
    /// <summary>
    /// Stores the function arguments to be used when checking if the function
    /// is cachable. Can be cleared using the ClearDataPostCache function
    /// </summary>
    private FnObject[] FunctionArguments_CacheCheck;

    /// <summary>
    /// Stores the data types for the arguments which this function will contain when filled.
    /// Is only populated if an FnFunction is constructed blankly.
    /// </summary>
    internal Type[] ArgumentTypes;

    /// <summary>
    /// The <see cref="CompileFlags"/> applied to this FnFunction"/>.
    /// </summary>
    internal CompileFlags[] Flags;

    /// <summary>
    /// Stores the field information for the FnFunction's arguments. Can be cleared using the ClearDataPostCache function.
    /// </summary>
    private FieldInfo[] ArgsInfo;

    internal FnVariable<Boolean> IsImmutableExecute;

    protected Dictionary<String, FnObject> Parameters;
    #endregion

    #region Constructors
    /// <summary>
    /// Constructor.
    /// </summary>
    public FnFunction() {
      Initialize(null);
    }

    /// <summary>
    /// Constructs a new <see cref="FnFunction{T}"/> with the specified list of compilation flags.
    /// </summary>
    /// <param name="flags">The list of compilation flags the function should have.</param>
    public FnFunction(CompileFlags[] flags) {
      Initialize(flags);
    }

    /// <summary>
    /// Initializer.
    /// </summary>
    /// <param name="flags">The list of compile flags the function should have</param>
    private void Initialize(CompileFlags[] flags) {
      // Compute argument types.

      // Start by getting all the FnArgs defined for the function
      ArgsInfo = this.GetType()
          .GetRuntimeFields()                                                 // Get fields.
          .Where(field => field.GetCustomAttribute(typeof(FnArg)) != null)    // That are also FnArgs.
          .ToArray<FieldInfo>();

      // Now sift through the collected arguments and extract the types their FnObjects encompass
      ArgumentTypes = new Type[ArgsInfo.Length];
      for (int i = 0; i < ArgsInfo.Length; i++) {
        ArgumentTypes[i] = ArgsInfo[i].FieldType.GenericTypeArguments[0];
      }

      // Set compile flags.
      Flags = (flags != null) ? flags : new CompileFlags[] { };
    }
    #endregion

    internal FnObject CreateNewBlankFunction() {
      return (FnObject)Activator.CreateInstance(this.GetType());
    }

    /// <summary>
    /// Gets the output of this <see cref="FnFunction{T}"/> as an <see cref="object"/>.
    /// </summary>
    public override object GetValueAsObject() {
      return (Object)GetValue();
    }

    internal FnObject CreateNewFunction(
      List<FnObject> functionArguments, Dictionary<String, FnObject> parameters, FnVariable<Boolean> isImmutableExecute
    ) {
      FnFunction<T> ReturnFunction = (CreateNewBlankFunction() as FnFunction<T>);
      ReturnFunction.Populate(functionArguments, parameters, isImmutableExecute);

      return ReturnFunction;
    }

    internal void Populate(
      List<FnObject> functionArguments, Dictionary<String, FnObject> parameters, FnVariable<Boolean> isImmutableExecute
    ) {
      IsImmutableExecute = isImmutableExecute;
      Parameters = parameters;

      FunctionArguments_CacheCheck = new FnObject[functionArguments.Count];

      for (int i = 0; i < FunctionArguments_CacheCheck.Length; i++) {
        FunctionArguments_CacheCheck[i] = functionArguments[i];
      }

      // Now we push these into our named function arguments
      for (int i = 0; i < functionArguments.Count; i++) {
        ArgsInfo[i].SetValue(this, functionArguments[i]);
      }
    }

    internal override bool IsCachable() {
      // The function is only cachable if it is cachable
      // And its arguments are cachable

      // If the function is cachable
      if (Flags != null && Flags.Contains(CompileFlags.DO_NOT_CACHE)) {
        return false;
      }

      // Check each function argument (must be either a const or a cachable function)
      if (FunctionArguments_CacheCheck != null) {
        for (int i = 0; i < FunctionArguments_CacheCheck.Length; i++) {
          if (!FunctionArguments_CacheCheck[i].IsCachable()) {
            return false;
          }
        }
      }

      return true;
    }

    internal override FnObject CheckAndCache() {
      // Optimize function arguments
      for (int i = 0; i < ArgsInfo.Length; i++) {
        // Assign the optimized function arguments using reflection
        ArgsInfo[i].SetValue(this, (ArgsInfo[i].GetValue(this) as FnObject).CheckAndCache());
      }

      // Optimize this node
      FnObject returnValue;
      if (IsCachable()) {
        returnValue = new FnConstant<T>(GetValue());
      } else {
        returnValue = this;
      }

      ClearDataPostCache();

      return returnValue;
    }

    /// <summary>
    /// Clears any data this is no longer needed after an FnFunction has been cached
    /// </summary>
    internal void ClearDataPostCache() {
      FunctionArguments_CacheCheck = null;
      ArgumentTypes = null;
      Flags = null;
      ArgsInfo = null;
    }
  }
}

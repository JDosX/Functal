using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FunctionScript {
  /// <summary>
  /// Reflection tag for identifying if an FnObject is a function argument in an FnMethod.
  /// </summary>
  [System.AttributeUsage(AttributeTargets.Field)]
  public class FnArg : Attribute { }

  [System.AttributeUsage(AttributeTargets.Class)]
  public class UseFunction : Attribute {
    /// <summary>
    /// The list of names the attached FnMethod could have.
    /// </summary>
    private string[] FunctionNames;

    public bool IsImmutable = false;
    public bool ImplicitConversion = false;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="functionNames">The list of names the attached FnMethod could have.</param>
    public UseFunction(params string[] functionNames) {
      FunctionNames = functionNames;
    }
  }

  /// <summary>
  /// Represents a FunctionScript Function.
  /// </summary>
  public abstract class FnMethod<T> : FnObject<T> {
    #region Nested Data Types
    /// <summary>
    /// Compiler flags which can be used in FnMethods to alter the way an <see cref="FnScriptExpression"/>
    /// is compiled.
    /// </summary>
    public enum CompileFlags {
      DO_NOT_CACHE = 0,
      IMPLICIT_CONVERSION,
    }
    #endregion

    #region Fields
    /// <summary>
    /// Stores the method arguments to be used when checking if the method
    /// is cachable. Can be cleared using the ClearDataPostCache method
    /// </summary>
    private FnObject[] MethodArguments_CacheCheck;

    /// <summary>
    /// Stores the data types for the arguments which this method will contain when filled.
    /// Is only populated if an FnMethod is constructed blankly.
    /// </summary>
    internal Type[] ArgumentTypes;

    /// <summary>
    /// The <see cref="CompileFlags"/> applied to this FnMethod"/>.
    /// </summary>
    internal CompileFlags[] Flags;

    /// <summary>
    /// Stores the field information for the FnMethod's arguments. Can be cleared using the ClearDataPostCache method.
    /// </summary>
    private FieldInfo[] ArgsInfo;

    internal FnVariable<Boolean> IsImmutableExecute;

    protected Dictionary<String, FnObject> Parameters;
    #endregion

    #region Constructors
    /// <summary>
    /// Creates a new FnMethod.
    /// </summary>
    public FnMethod() {
      Initialize(null);
    }

    /// <summary>
    /// Creates a new FnMethod with the specified list of compiler flags.
    /// </summary>
    /// <param name="flags">The list of compile flags the method should have</param>
    public FnMethod(CompileFlags[] flags) {
      Initialize(flags);
    }

    /// <summary>
    /// Initializer.
    /// </summary>
    /// <param name="flags">The list of compile flags the method should have</param>
    private void Initialize(CompileFlags[] flags) {
      // Compute argument types.

      // Start by getting all the FnArgs defined for the method
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

    internal FnObject CreateNewBlankMethod() {
      return (FnObject)Activator.CreateInstance(this.GetType());
    }

    /// <summary>
    /// Gets the value of the data wrapped by this FnObject as an <see cref="object"/>.
    /// </summary>
    public override object GetValueAsObject() {
      return (Object)GetValue();
    }

    internal FnObject CreateNewMethod(
      List<FnObject> methodArguments, Dictionary<String, FnObject> parameters, FnVariable<Boolean> isImmutableExecute
    ) {
      FnMethod<T> ReturnMethod = (CreateNewBlankMethod() as FnMethod<T>);
      ReturnMethod.Populate(methodArguments, parameters, isImmutableExecute);

      return ReturnMethod;
    }

    internal void Populate(
      List<FnObject> methodArguments, Dictionary<String, FnObject> parameters, FnVariable<Boolean> isImmutableExecute
    ) {
      IsImmutableExecute = isImmutableExecute;
      Parameters = parameters;

      MethodArguments_CacheCheck = new FnObject[methodArguments.Count];

      for (int i = 0; i < MethodArguments_CacheCheck.Length; i++) {
        MethodArguments_CacheCheck[i] = methodArguments[i];
      }

      // Now we push these into our named method arguments
      for (int i = 0; i < methodArguments.Count; i++) {
        ArgsInfo[i].SetValue(this, methodArguments[i]);
      }
    }

    internal override bool IsCachable() {
      // The method is only cachable if it is cachable
      // And its arguments are cachable

      // If the method is cachable
      if (Flags != null && Flags.Contains(CompileFlags.DO_NOT_CACHE)) {
        return false;
      }

      // Check each method argument (must be either a const or a cachable method)
      if (MethodArguments_CacheCheck != null) {
        for (int i = 0; i < MethodArguments_CacheCheck.Length; i++) {
          if (!MethodArguments_CacheCheck[i].IsCachable()) {
            return false;
          }
        }
      }

      return true;
    }

    internal override FnObject CheckAndCache() {
      // Optimize method arguments
      for (int i = 0; i < ArgsInfo.Length; i++) {
        // Assign the optimized method arguments using reflection
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
    /// Clears any data this is no longer needed after an FnMethod has been cached
    /// </summary>
    internal void ClearDataPostCache() {
      MethodArguments_CacheCheck = null;
      ArgumentTypes = null;
      Flags = null;
      ArgsInfo = null;
    }
  }
}

using System;
using System.Collections.Generic;

namespace FunctionScript {

  /// <summary>
  /// Represents a FunctionScript expression.
  /// </summary>
  public abstract class FnScriptExpression {
    
    /// <summary>
    /// Stores whether the expression is executing immutably.
    /// </summary>
    internal FnVariable<Boolean> IsImmutableExecute;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="isImmutableExecute">The FnVariable to fill when performing an immutable execution.</param>
    protected FnScriptExpression(FnVariable<Boolean> isImmutableExecute) {
      IsImmutableExecute = isImmutableExecute;
    }
  }

  /// <summary>
  /// Represents a FunctionScript expression.
  /// </summary>
  /// <typeparam name="T">The return type of the expression.</typeparam>
  public class FnScriptExpression<T> : FnScriptExpression {
    
    /// <summary>
    /// The raw expression that was used to compile this FnScriptExpression.
    /// </summary>
    public readonly String RawExpression;

    /// <summary>
    /// Stores an aggregation of all the parameters accessible from this expression,  obeying Local, Collection and
    /// Global precedence rules.
    /// </summary>
    private Dictionary<String, FnObject> Parameters;

    /// <summary>
    /// The root node of the execution tree. The FnScriptExpression is executed by polling this FnObject for its value.
    /// </summary>
    /// <remarks>
    /// The wrapped type of this FnObject will always match the return type of the FnScriptExpression.
    /// </remarks>
    private FnObject<T> ExecutionNode;

    /// <summary>
    /// The default constructor, creates a new blank FnScriptExpression
    /// </summary>
    internal FnScriptExpression(
      FnObject<T> executionNode, string rawExpression,
      Dictionary<String, FnObject> parameters, FnVariable<Boolean> isPreExecute
    ) : base(isPreExecute) {
      RawExpression = rawExpression;
      ExecutionNode = executionNode;
      Parameters = parameters;
    }

    /// <summary>
    /// Sets the value of a parameter in the collection parameter dictionary with the given name
    /// </summary>
    /// <typeparam name="TInput">The data type of the value to assign to the collection parameter</typeparam>
    /// <param name="parameterName">The name of the collection parameter</param>
    /// <param name="parameterValue">The value to assign to the collection parameter</param>
    public void SetParameter<TInput>(String parameterName, TInput parameterValue) {
      if (Parameters.ContainsKey(parameterName)) {
        if (Parameters[parameterName] is FnVariable<TInput>) {
          (Parameters[parameterName] as FnVariable<TInput>).Value = parameterValue;
        } else {
          throw new ArgumentException(String.Format(
            "Parameter/input type mismatch. Expected type {0}, recieved value of type {1}.",
            Parameters[parameterName].GetWrappedObjectType(), typeof(TInput).ToString()
          ));
        }
      } else {
        throw new ArgumentException("No parameter of this name exists");
      }
    }

    /// <summary>
    /// Returns the data type this expression will return when executed.
    /// </summary>
    public Type GetReturnType() {
      return typeof(T);
    }

    /// <summary>
    /// Executes the expression immutably and returns the result. Immutable execution means the expression runs
    /// without incurring any changes in global state.
    /// </summary>
    /// <remarks>
    /// For immutable execution to work correctly it requires immutable support from each of the methods that it
    /// uses. 
    /// </remarks>
    /// <returns>The computed result of the expression. Note: If a function used in the expression relies on a state
    /// to compute results, then you may notice a change in returned value when compared to using Execute.</returns>
    public T ImmutableExecute() {
      IsImmutableExecute.Value = true;
      T data = ExecutionNode.GetValue();
      IsImmutableExecute.Value = false;

      return data;
    }

    /// <summary>
    /// Executes the expression and returns the result whilst storing it.
    /// </summary>
    /// <returns>The result of the expression execution</returns>
    public T Execute() {
      return ExecutionNode.GetValue();
    }
  }
}

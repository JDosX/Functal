using System;
using System.Collections.Generic;

namespace Functal {

  /// <summary>
  /// Represents a Functal expression.
  /// </summary>
  public abstract class FunctalExpression {
    /// <summary>
    /// Stores whether the expression is executing immutably.
    /// </summary>
    internal FnVariable<Boolean> IsImmutableExecute;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="isImmutableExecute">The FnVariable to fill when performing an immutable execution.</param>
    protected FunctalExpression(FnVariable<Boolean> isImmutableExecute) {
      IsImmutableExecute = isImmutableExecute;
    }
  }

  /// <summary>
  /// Represents a Functal expression.
  /// </summary>
  /// <typeparam name="T">The return type of the expression.</typeparam>
  public class FunctalExpression<T> : FunctalExpression {
    
    /// <summary>
    /// The raw string this <see cref="FunctalExpression{T}"/> was compiled from.
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
    internal FunctalExpression(
      FnObject<T> executionNode, string rawExpression,
      Dictionary<String, FnObject> parameters, FnVariable<Boolean> isPreExecute
    ) : base(isPreExecute) {
      RawExpression = rawExpression;
      ExecutionNode = executionNode;
      Parameters = parameters;
    }

    /// <summary>
    /// Sets the parameter of the specified name to the specified value.
    /// </summary>
    /// <typeparam name="TInput">The data type of the parameter.</typeparam>
    /// <param name="parameterName">The name of the parameter.</param>
    /// <param name="parameterValue">The value to assign to the parameter.</param>
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
    /// Gets the return type of this <see cref="FunctalExpression{T}"/>.
    /// </summary>
    public Type GetReturnType() {
      return typeof(T);
    }

    /// <summary>
    /// Executes the expression immutably and returns the result. Immutable execution means the
    /// expression executes without changing the program's state.
    /// </summary>
    /// <remarks>
    /// For immutable execution to work correctly it requires immutable support from each of the
    /// functionsthat it uses. 
    /// </remarks>
    /// <returns>The computed result of the expression. If a function used in the expression relies
    /// on a state change to compute results, you may notice the returned value differs when
    /// compared to calling <see cref="Execute"/>.</returns>
    public T ImmutableExecute() {
      IsImmutableExecute.Value = true;
      T data = ExecutionNode.GetValue();
      IsImmutableExecute.Value = false;

      return data;
    }

    /// <summary>
    /// Executes the expression and returns the result.
    /// </summary>
    /// <returns>The computed result of the expression.</returns>
    public T Execute() {
      return ExecutionNode.GetValue();
    }
  }
}

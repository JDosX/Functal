using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunctionScript
{
    public abstract class FnScriptExpression
    {
        internal FnVariable<Boolean> IsPreExecute;

        public FnScriptExpression(FnVariable<Boolean> isPreExecute)
        {
            IsPreExecute = isPreExecute;
        }
    }

    /// <summary>
    /// Represents a FnScript expression, which is compiled from an imput string by calling the Compile method and then evaluated by calling the Execute method
    /// </summary>
    /// <typeparam name="T">The return type of the expression</typeparam>
    public class FnScriptExpression<T> : FnScriptExpression
    {

        /// <summary>
        /// Contains the raw expression that was used to compile this FnScriptExpression
        /// </summary>
        public readonly String RawExpression;
        /// <summary>
        /// Stores an aggregation of all the parameters accessible from this expression,
        /// obeying Local, Collection and Global precedence rules
        /// </summary>
        private Dictionary<String, FnObject> Parameters;
        /// <summary>
        /// This is the root node of the execution tree. This has its own reference for faster access, and
        /// because we know its return type will match the type of the expression
        /// </summary>
        public FnObject<T> ExecutionNode;

        /// <summary>
        /// The default constructor, creates a new blank FnScriptExpression
        /// </summary>
        public FnScriptExpression(FnObject<T> executionNode, string rawExpression, Dictionary<String, FnObject> parameters, FnVariable<Boolean> isPreExecute)
            : base(isPreExecute)
        {
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
        public void SetParameter<TInput>(String parameterName, TInput parameterValue)
        {
            if (Parameters.ContainsKey(parameterName))
            {
                if (Parameters[parameterName] is FnVariable<TInput>)
                {
                    (Parameters[parameterName] as FnVariable<TInput>).Value = parameterValue;
                }
                else
                {
                    throw new ArgumentException("Parameter/input type mismatch, expected type " + Parameters[parameterName].GetWrappedObjectType().ToString() + ", recieved value of type " + typeof(TInput).ToString());
                }
            }
            else
            {
                throw new ArgumentException("No parameter of this name exists");
            }
        }

        /// <summary>
        /// Returns the data type this expression will return when executed
        /// </summary>
        /// <returns></returns>
        public Type GetTypeOfObject()
        {
            return typeof(T);
        }

        public T PreExecute()
        {
            IsPreExecute.Value = true;
            T data = ExecutionNode.GetValue();
            IsPreExecute.Value = false;

            return data;
        }

        /// <summary>
        /// Executes the expression and returns the result whilst storing it
        /// </summary>
        /// <returns>The result of the expression execution</returns>
        public T Execute()
        {
            return ExecutionNode.GetValue();
        }
    }
}

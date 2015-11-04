using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunctionScript
{
    /// <summary>
    /// The generic interface for an FnMethodPointer
    /// </summary>
    public interface FnMethodPointer
    {
        /// <summary>
        /// Gets the return type of the contained method reference
        /// </summary>
        /// <returns></returns>
        Type GetTypeOfObject();
        /// <summary>
        /// Creates an FnObject using the contained method reference
        /// </summary>
        /// <param name="methodParameters">The parameters to use in the method call</param>
        /// <param name="ghostParameters">The ghost parameters that can be accessed from the method implementation without declaring them</param>
        /// <param name="compileFlags">Compile flags to be assigned to the FnObject that is created. These change the way the FnObject is compiled</param>
        /// <returns></returns>
        FnObject CreateObjectWithPointer(List<FnObject> methodParameters, Dictionary<String, FnObject> parameters, FnVariable<Boolean> isPreExecute);

        Type[] GetMethodTypeArray();
    }

    /// <summary>
    /// Stores a reference to a Func with a list of FnObjects as the specified arguments,
    /// and can be used to create an FnObject containing the method reference
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class FnMethodPointer<T> : FnMethodPointer
    {
        /// <summary>
        /// The method reference this FnMethodPointer wraps
        /// </summary>
        public readonly FnMethod<T> Target;

        /// <summary>
        /// The constructor, creates an FnMethodPointer containing the specified method reference
        /// </summary>
        /// <param name="target"></param>
        public FnMethodPointer(FnMethod<T> target)
        {
            //I shouldn't need to worry about creating a blank verion of the FnMethod, unless
            //I want to ensure the method provided isn't lugging unneccessary data around (potential security flaw)
            Target = target;
        }

        /// <summary>
        /// Gets the return type of the contained method reference
        /// </summary>
        /// <returns></returns>
        public Type GetTypeOfObject()
        {
            return typeof(T);
        }

        /// <summary>
        /// Creates an FnObject using the contained method reference
        /// </summary>
        /// <param name="methodParameters">The parameters to use in the method call</param>
        /// <param name="ghostParameters">The ghost parameters that can be accessed from the method implementation without declaring them</param>
        /// <param name="compileFlags">Compile flags to be assigned to the FnObject that is created. These change the way the FnObject is compiled</param>
        /// <returns></returns>
        public FnObject CreateObjectWithPointer(List<FnObject> methodParameters, Dictionary<String, FnObject> parameters, FnVariable<Boolean> isPreExecute)
        {
            return Target.CreateNewMethod(methodParameters, parameters, isPreExecute);
        }

        public Type[] GetMethodTypeArray()
        {
            return Target.ArgumentTypes;
        }
    }
}

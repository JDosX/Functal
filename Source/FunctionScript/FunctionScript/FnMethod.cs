using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Reflection;

namespace FunctionScript
{
    public abstract class FnMethod<T> : FnObject<T>
    {
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
        /// The local variable which stores the values which are used by the CompileFlags Property
        /// </summary>
        internal FnScriptResources.CompileFlags[] CompileFlags;

        /// <summary>
        /// Stores the field information for the FnMethod's arguments.
        /// Can be cleared using the ClearDataPostCache method
        /// </summary>
        private FieldInfo[] ArgsInfo;

        internal FnVariable<Boolean> IsPreExecute;

        protected Dictionary<String, FnObject> Parameters;
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new blank FnMethod
        /// </summary>
        /// <param name="argumentTypes">The datatype of each consecutive method argument</param>
        internal FnMethod()
        {
            Construct(null);
        }
        
        /// <summary>
        /// Creates a new blank FnMethod
        /// </summary>
        /// <param name="argumentTypes">The datatype of each consecutive method argument</param>
        /// <param name="compileFlags">The list of compile flags the method should have</param>
        internal FnMethod(FnScriptResources.CompileFlags[] compileFlags)
        {
            Construct(compileFlags);
        }
        
        /// <summary>
        /// Constructs a blank FnMethod, called by the Constructors
        /// </summary>
        /// <param name="argumentTypes">The datatype of each consecutive method argument</param>
        /// <param name="compileFlags">The list of compile flags the method should have</param>
        private void Construct(FnScriptResources.CompileFlags[] compileFlags)
        {
            // Construct Argument Types

            // Start by getting all the FnArgs defined for the method
            ArgsInfo = this.GetType()
                .GetRuntimeFields()                                                 // get fields
                .Where(field => field.GetCustomAttribute(typeof(FnArg)) != null)    // that are also FnArgs
                .ToArray<FieldInfo>();

            // Now sift through the collected arguments and extract the types their FnObjects encompass
            ArgumentTypes = new Type[ArgsInfo.Length];
            for (int i = 0; i < ArgsInfo.Length; i++)
            {
                ArgumentTypes[i] = ArgsInfo[i].FieldType.GenericTypeArguments[0];
            }

            CompileFlags = (compileFlags != null) ? compileFlags : new FnScriptResources.CompileFlags[] { };
        }
        #endregion

        public FnObject CreateNewBlankMethod()
        {
            return (FnObject)Activator.CreateInstance(this.GetType());
        }

        public override object GetValueAsObject()
        {
            return (Object)GetValue();
        }

        internal FnObject CreateNewMethod(List<FnObject> methodArguments, Dictionary<String, FnObject> parameters, FnVariable<Boolean> isPreExecute)
        {
            FnMethod<T> ReturnMethod = (CreateNewBlankMethod() as FnMethod<T>);
            ReturnMethod.Populate(methodArguments, parameters, isPreExecute);

            return ReturnMethod;
        }

        internal void Populate(List<FnObject> methodArguments, Dictionary<String, FnObject> parameters, FnVariable<Boolean> isPreExecute)
        {
            IsPreExecute = isPreExecute;
            Parameters = parameters;

            MethodArguments_CacheCheck = new FnObject[methodArguments.Count];

            for (int i = 0; i < MethodArguments_CacheCheck.Length; i++)
            {
                MethodArguments_CacheCheck[i] = methodArguments[i];
            }

            //Now we push these into our named method arguments
            for (int i = 0; i < methodArguments.Count; i++)
            {
                ArgsInfo[i].SetValue(this, methodArguments[i]);
            }
        }

        internal override bool IsCachable()
        {
            // The method is only cachable if it is cachable
            // And its arguments are cachable

            // If the method is cachable
            if (CompileFlags != null && CompileFlags.Contains(FnScriptResources.CompileFlags.DO_NOT_CACHE))
            {
                return false;
            }

            // Check each method argument (must be either a const or a cachable method)
            if (MethodArguments_CacheCheck != null)
            {
                for (int i = 0; i < MethodArguments_CacheCheck.Length; i++)
                {
                    if (!MethodArguments_CacheCheck[i].IsCachable())
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Clears any data this is no longer needed after an FnMethod has been cached
        /// </summary>
        internal void ClearDataPostCache()
        {
            MethodArguments_CacheCheck = null;
            ArgumentTypes = null;
            CompileFlags = null;
            ArgsInfo = null;
        }
    }
}

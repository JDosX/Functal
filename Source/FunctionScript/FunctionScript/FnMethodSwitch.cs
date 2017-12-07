using System;
using System.Collections.Generic;

namespace FunctionScript
{
    /// <summary>
    /// Is used to define a method callable from fnScript, encapsulates all possible overloads, and returns the corrent one to the compiler based on input parameters
    /// </summary>
    internal class FnMethodSwitch
    {
        /// <summary>
        /// The method name
        /// </summary>
        public readonly String Name;
        /// <summary>
        /// Pointers for each method overload
        /// </summary>
        internal List<FnMethodPointer> MethodPointers;

        /// <summary>
        /// Creats a new FnMethodSwitch
        /// </summary>
        /// <param name="name">The name you want to give your switch. This becomes your method name when you want to call the method in fnScript</param>
        /// <param name="compileFlags">Any compile flags the method switch neds</param>
        public FnMethodSwitch(String name)
        {
            MethodPointers = new List<FnMethodPointer>();

            Name = name;
        }

        /// <summary>
        /// Adds a method overload to the swtich
        /// </summary>
        /// <param name="methodPointer">The FnMethodPointer that contains the reference to the C# method"</param>
        /// <param name="argumentTypes">The data types of the method arguments</param>
        public void AddMethodPointer(FnMethodPointer methodPointer)
        {
            Type[] newMethodTypeArray = methodPointer.GetMethodTypeArray();

            //check that an overload of these method types hasn't been previously entered
            for (int i = 0; i < MethodPointers.Count; i++)
            {
                Type[] currentMethodsTypeArray = MethodPointers[i].GetMethodTypeArray();

                //if we find a potential overload match
                if (currentMethodsTypeArray.Length == newMethodTypeArray.Length)
                {
                    for (int j = 0; j < currentMethodsTypeArray.Length; j++)
                    {
                        //if we find a mismatch
                        if (currentMethodsTypeArray[j] != newMethodTypeArray[j])
                        {
                            break;
                        }
                        //else if we get to the end of the list with no mistakes
                        else if (j == currentMethodsTypeArray.Length - 1)
                        {
                            throw new ArgumentException("The Argument types you have submitted have been previously entered for another overload", "Conflicting overload data: " + newMethodTypeArray.ToString());
                        }
                    }
                }
            }

            MethodPointers.Add(methodPointer);
        }

        /// <summary>
        /// Creates an FnObject which contains the method pointer that match the specified arguments
        /// </summary>
        /// <param name="arguments">The method arguments to use</param>
        /// <param name="ghostArguments">Any ghost arguments you want to add to the FnObject</param>
        /// <returns></returns>
        public FnObject CreateObjectWithPointer(List<FnObject> arguments, Dictionary<String, FnObject> parameters, FnVariable<Boolean> isPreExecute)
        {
            //try to find an exact match
            for (int i = 0; i < MethodPointers.Count; i++)
            {
                Type[] currentMethodsTypeArray = MethodPointers[i].GetMethodTypeArray();

                //if we find a potential overload match
                if (currentMethodsTypeArray.Length == arguments.Count)
                {
                    for (int j = 0; j < currentMethodsTypeArray.Length; j++)
                    {
                        //if we find a mismatch
                        if (currentMethodsTypeArray[j] != arguments[j].GetWrappedObjectType())
                        {
                            break;
                        }
                        //else if we get to the end of the list with no mistakes
                        else if (j == currentMethodsTypeArray.Length - 1)
                        {
                            return MethodPointers[i].CreateObjectWithPointer(arguments, parameters, isPreExecute);
                        }
                    }
                }
            }

            //we didn't get an exact match, now iterate through each overload and find the least ambiguous one (this will only happen for numeric data types)
            List<Int32> Ambiguity = new List<Int32>(MethodPointers.Count);

            for (int i = 0; i < MethodPointers.Count; i++)
            {
                Type[] currentMethodsTypeArray = MethodPointers[i].GetMethodTypeArray();

                if (currentMethodsTypeArray.Length == arguments.Count)
                {
                    //add new count to the ambiguity list and increment it with each type and argument analysed
                    Ambiguity.Add(0);

                    for (int j = 0; j < currentMethodsTypeArray.Length; j++)
                    {
                        //if we have two conflicting data types
                        if (currentMethodsTypeArray[j] != arguments[j].GetWrappedObjectType())
                        {
                            Int32 TypeAmbiguity = FnScriptResources.GetAmbiguityScore(currentMethodsTypeArray[j], arguments[j].GetWrappedObjectType());
                            if (TypeAmbiguity <= 0) //if this is 0, then our two types are on the same level of ambiguity and so are unable to up cast. If it is less than zero, than the one to cast to is of a lower data type, so up casting isn't possible
                            {
                                Ambiguity[i] = -1;
                                break;
                            }
                            else
                            {
                                Ambiguity[i] += TypeAmbiguity;
                            }
                        }
                    }
                }
                else
                {
                    Ambiguity.Add(-1);
                }
            }

            //we now have a list of the ambiguities for all the method overloads, we now need to find the lowest
            //non negative ambiguity score, and make sure there are no others which have it.

            Int32 LowestScoreIndex = -1;
            Int32 LowestScoreCount = 1;

            for (int i = 0; i < Ambiguity.Count; i++)
            {
                if (Ambiguity[i] >= 0)
                {
                    if (LowestScoreIndex == -1)
                    {
                        LowestScoreIndex = i;
                    }
                    else
                    {
                        if (Ambiguity[i] < Ambiguity[LowestScoreIndex])
                        {
                            LowestScoreIndex = i;
                            LowestScoreCount = 1;
                        }
                        else if (Ambiguity[i] == Ambiguity[LowestScoreIndex])
                        {
                            LowestScoreCount += 1;
                        }
                    }
                }
            }

            if (LowestScoreIndex >= 0 && LowestScoreCount == 1)
            {
                //now we iterate through the list of arguments, and everywhere we have a type mismatch, we replace the argument with
                //an implicit cast of the argument to the correct data type

                for (int i = 0; i < arguments.Count; i++)
                {
                    if (MethodPointers[LowestScoreIndex].GetMethodTypeArray()[i] != arguments[i].GetWrappedObjectType())
                    {
                        arguments[i] = FnScriptResources.ImplicitConversionSwitches[MethodPointers[LowestScoreIndex].GetMethodTypeArray()[i]].CreateObjectWithPointer(new List<FnObject> { arguments[i] }, parameters, isPreExecute);

                            //ExecutionList.Add(FnScriptResources.ImplicitConversionSwitches[typeof(T)].CreateObjectWithPointer(new List<FnObject> { ExecutionList.Last() }, GhostArguments));
                    }
                }

                return MethodPointers[LowestScoreIndex].CreateObjectWithPointer(arguments, parameters, isPreExecute);
            }
            else if (LowestScoreIndex >= 0 && LowestScoreCount > 1)
            {
                throw new ArgumentException("The method call is too ambiguous to resolve, use more specific argument types", arguments.ToString());
            }
            else
            {
                throw new ArgumentException("The method has no overloads which match the specified arguments", arguments.ToString());
            }
        }
    }
}


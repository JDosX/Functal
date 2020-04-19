using System;
using System.Collections.Generic;

namespace Functal {
  /// <summary>
  /// Is used to define a function callable from fnScript, encapsulates all possible overloads, and returns the corrent
  /// one to the compiler based on input parameters.
  /// </summary>
  internal class FnFunctionGroup {
    /// <summary>
    /// The function name
    /// </summary>
    public readonly String Name;

    /// <summary>
    /// Pointers for each function overload
    /// </summary>
    public List<FnFunctionPointer> FunctionPointers;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="name">The name of the function group. This becomes your function name when you want to call the function in fnScript</param>
    public FnFunctionGroup(String name) {
      FunctionPointers = new List<FnFunctionPointer>();

      Name = name;
    }

    /// <summary>
    /// Adds a function overload to the group.
    /// </summary>
    /// <param name="functionpointer">The <see cref="FnFunctionPointer"/> that contains the reference to the C# method."</param>
    public void AddFunctionPointer(FnFunctionPointer functionpointer) {
      Type[] newFunctionTypeArray = functionpointer.GetFunctionTypeArray();

      //check that an overload of these function types hasn't been previously entered
      for (int i = 0; i < FunctionPointers.Count; i++) {
        Type[] currentFunctionsTypeArray = FunctionPointers[i].GetFunctionTypeArray();

        //if we find a potential overload match
        if (currentFunctionsTypeArray.Length == newFunctionTypeArray.Length) {
          for (int j = 0; j < currentFunctionsTypeArray.Length; j++) {
            //if we find a mismatch
            if (currentFunctionsTypeArray[j] != newFunctionTypeArray[j]) {
              break;
            }
            //else if we get to the end of the list with no mistakes
            else if (j == currentFunctionsTypeArray.Length - 1) {
              throw new ArgumentException("The Argument types you have submitted have been previously entered for another overload", "Conflicting overload data: " + newFunctionTypeArray.ToString());
            }
          }
        }
      }

      FunctionPointers.Add(functionpointer);
    }

    /// <summary>
    /// Creates an FnObject which contains the function pointer that match the specified arguments
    /// </summary>
    /// <param name="arguments">The function arguments to use</param>
    /// <param name="ghostArguments">Any ghost arguments you want to add to the FnObject</param>
    /// <returns></returns>
    public FnObject CreateObjectWithPointer(List<FnObject> arguments, Dictionary<String, FnObject> parameters, FnVariable<Boolean> isPreExecute) {
      //try to find an exact match
      for (int i = 0; i < FunctionPointers.Count; i++) {
        Type[] currentFunctionsTypeArray = FunctionPointers[i].GetFunctionTypeArray();

        //if we find a potential overload match
        if (currentFunctionsTypeArray.Length == arguments.Count) {
          for (int j = 0; j < currentFunctionsTypeArray.Length; j++) {
            //if we find a mismatch
            if (currentFunctionsTypeArray[j] != arguments[j].GetWrappedObjectType()) {
              break;
            }
            //else if we get to the end of the list with no mistakes
            else if (j == currentFunctionsTypeArray.Length - 1) {
              return FunctionPointers[i].CreateObjectWithPointer(arguments, parameters, isPreExecute);
            }
          }
        }
      }

      //we didn't get an exact match, now iterate through each overload and find the least ambiguous one (this will only happen for numeric data types)
      List<Int32> Ambiguity = new List<Int32>(FunctionPointers.Count);

      for (int i = 0; i < FunctionPointers.Count; i++) {
        Type[] currentFunctionsTypeArray = FunctionPointers[i].GetFunctionTypeArray();

        if (currentFunctionsTypeArray.Length == arguments.Count) {
          //add new count to the ambiguity list and increment it with each type and argument analysed
          Ambiguity.Add(0);

          for (int j = 0; j < currentFunctionsTypeArray.Length; j++) {
            //if we have two conflicting data types
            if (currentFunctionsTypeArray[j] != arguments[j].GetWrappedObjectType()) {
              Int32 TypeAmbiguity = FunctalResources.GetAmbiguityScore(currentFunctionsTypeArray[j], arguments[j].GetWrappedObjectType());
              if (TypeAmbiguity <= 0) //if this is 0, then our two types are on the same level of ambiguity and so are unable to up cast. If it is less than zero, than the one to cast to is of a lower data type, so up casting isn't possible
              {
                Ambiguity[i] = -1;
                break;
              } else {
                Ambiguity[i] += TypeAmbiguity;
              }
            }
          }
        } else {
          Ambiguity.Add(-1);
        }
      }

      //we now have a list of the ambiguities for all the function overloads, we now need to find the lowest
      //non negative ambiguity score, and make sure there are no others which have it.

      Int32 LowestScoreIndex = -1;
      Int32 LowestScoreCount = 1;

      for (int i = 0; i < Ambiguity.Count; i++) {
        if (Ambiguity[i] >= 0) {
          if (LowestScoreIndex == -1) {
            LowestScoreIndex = i;
          } else {
            if (Ambiguity[i] < Ambiguity[LowestScoreIndex]) {
              LowestScoreIndex = i;
              LowestScoreCount = 1;
            } else if (Ambiguity[i] == Ambiguity[LowestScoreIndex]) {
              LowestScoreCount += 1;
            }
          }
        }
      }

      if (LowestScoreIndex >= 0 && LowestScoreCount == 1) {
        // Now we iterate through the list of arguments, and everywhere we have a type mismatch, we replace the argument
        // with an implicit cast of the argument to the correct data type

        for (int i = 0; i < arguments.Count; i++) {
          if (FunctionPointers[LowestScoreIndex].GetFunctionTypeArray()[i] != arguments[i].GetWrappedObjectType()) {
            arguments[i] = FunctalResources.ImplicitConversionSwitches[FunctionPointers[LowestScoreIndex].GetFunctionTypeArray()[i]].CreateObjectWithPointer(new List<FnObject> { arguments[i] }, parameters, isPreExecute);

            //ExecutionList.Add(FnScriptResources.ImplicitConversionSwitches[typeof(T)].CreateObjectWithPointer(new List<FnObject> { ExecutionList.Last() }, GhostArguments));
          }
        }

        return FunctionPointers[LowestScoreIndex].CreateObjectWithPointer(arguments, parameters, isPreExecute);
      } else if (LowestScoreIndex >= 0 && LowestScoreCount > 1) {
        throw new ArgumentException(
          "The function call is too ambiguous to resolve, use more specific argument types", arguments.ToString()
        );
      } else {
        throw new ArgumentException(
          "The function has no overloads which match the specified arguments", arguments.ToString()
        );
      }
    }
  }
}


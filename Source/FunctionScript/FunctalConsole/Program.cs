using System;
using Functal;

/// <summary>
/// Returns true if the specified number is less than 5, false if not.
/// </summary>
class FnFunction_IsLessThanFive : FnFunction<bool>
{
  /// <summary>First argument: The number to check.</summary>
  [FnArg] protected FnObject<int> Number;

  public override bool GetValue() {
    return Number.GetValue() < 5;
  }
}

/// <summary>
/// Returns true if a string has less than 5 characters, false if not.
/// </summary>
class FnFunction_IsLessThanFiveChars : FnFunction<bool>
{
  /// <summary>The string to check.</summary>
  [FnArg] protected FnObject<string> Text;

  public override bool GetValue() {
    return Text.GetValue().Length < 5;
  }
}

class Program
{
  static void Main(string[] args) {
    // Add custom function to Functal.
    FunctalResources.CreateFunctionGroup("IsLessThanFive");
    FunctalResources.AddFunctionToGroup("IsLessThanFive", new FnFunction_IsLessThanFive());
    FunctalResources.AddFunctionToGroup("IsLessThanFive", new FnFunction_IsLessThanFiveChars());

    FunctalCompiler compiler = new FunctalCompiler();
    Console.WriteLine(
      compiler.Compile<string>(
        "\"First Result: \" + ToString(IsLessThanFive(3))", null
      ).Execute()
    );
    Console.WriteLine(
      compiler.Compile<string>(
        "\"Second Result: \" + ToString(IsLessThanFive(7))", null
      ).Execute()
    );
    Console.WriteLine(
      compiler.Compile<string>(
        "\"Third Result: \" + ToString(IsLessThanFive(\"Definitely More Than Five Characters\"))",
        null
      ).Execute()
    );

    Console.ReadKey();
  }
}
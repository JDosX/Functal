using System;
using Functal;

namespace FunctalConsole
{
  class Program
  {
    static void Main(string[] args) {
      FunctalCompiler compiler = new FunctalCompiler();
      FunctalExpression<char> dudExpression = compiler.Compile<char>("if (true, 'a', 'b')");

      Console.WriteLine(dudExpression.Execute());
    }
  }
}

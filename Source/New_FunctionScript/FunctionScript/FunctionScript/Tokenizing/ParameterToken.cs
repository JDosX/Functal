using System.Collections.Generic;
using Amadeus.Tokenizing;

namespace FunctionScript.Tokenizing {
  internal sealed class ParameterToken : Token {
    internal sealed class Builder : Token.Builder {
      protected override IEnumerator<BuildState> NextChar(CharContainer c) {
        // First character must be [.
        if (c.Value != '[') {
          yield break;
        } else {
          yield return BuildState.Invalid;
        }

        // The name must be at least one character long.
        if (c.Value == ']') {
          yield break;
        } else {
          yield return BuildState.Invalid;
        }

        // Trailing name characters.
        while (c.Value != ']') {
          yield return BuildState.Invalid;
        }

        // Once a ] is found, the parameter is valid and can exit.
        yield return BuildState.Valid;
        yield break;
      }
    }
  }
}

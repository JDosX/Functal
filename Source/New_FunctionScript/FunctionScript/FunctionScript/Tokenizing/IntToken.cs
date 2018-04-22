using System;
using System.Collections.Generic;
using Amadeus.Tokenizing;

namespace FunctionScript.Tokenizing {
  internal sealed class IntToken : Token {
    internal sealed class Builder : Token.Builder {
      protected override IEnumerator<BuildState> NextChar(CharContainer c) {
        // Int must have at least one digit.
        if (!Char.IsDigit(c.Value)) {
          yield break;
        } else {
          yield return BuildState.Valid;
        }

        // Trailing digits.
        while (Char.IsDigit(c.Value)) {
          yield return BuildState.Valid;
        }
        yield break;
      }
    }
  }
}

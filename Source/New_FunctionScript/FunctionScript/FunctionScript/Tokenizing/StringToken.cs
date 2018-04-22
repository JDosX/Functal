using System;
using System.Collections.Generic;
using Amadeus.Tokenizing;

namespace FunctionScript.Tokenizing {
  internal sealed class StringToken : Token {
    internal sealed class Builder : Token.Builder {
      protected override IEnumerator<BuildState> NextChar(CharContainer c) {
        if (c.Value != '"') {
          yield break;
        }
        yield return BuildState.Invalid;

        while (c.Value != '"') {
          if (c.Value == '\\') {
            yield return BuildState.Invalid;
            // TODO: HANDLE ESCAPE CHARS. The below just consumes the next char no matter what it
            // is. Is that appropriate?
            yield return BuildState.Invalid;
          } else {
            yield return BuildState.Invalid;
          }
        }

        yield return BuildState.Valid;
        yield break;
      }
    }

    public StringToken() {
    }
  }
}

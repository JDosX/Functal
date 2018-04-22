using System.Collections.Generic;
using Amadeus.Tokenizing;

namespace FunctionScript.Tokenizing {
  internal sealed class CharToken : Token {
    internal sealed class Builder : Token.Builder {
      protected override IEnumerator<Token.Builder.BuildState> NextChar(CharContainer c) {
        // TODO: FINISH THIS.

        // Must start with '
        if (c.Value == '\'') {
          yield return BuildState.Invalid;
        } else {
          yield break;
        }

        // A char cannot be empty.
        if (c.Value == '\'') {
          yield break;
        } else if (c.Value == '\\') { // Handle escape characters
          yield return BuildState.Invalid;

          // TODO: HANDLE ESCAPE CHARS.
          // Where should we do this? If we detect an invalid escape char we should print a specific error message for that.
          // We should add error reporting to tokenizing.
        } else {
          yield return BuildState.Invalid;
        }

        // Must end with '
        if (c.Value == '\'') {
          yield return BuildState.Valid;
          yield break;
        } else {
          yield break;
        }
      }
    }
  }
}

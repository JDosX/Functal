using System;
using System.Collections.Generic;
using Amadeus.Tokenizing;

namespace FunctionScript.Tokenizing {
  internal sealed class ConstToken : Token {
    protected override IEnumerator<TokenState> Feed(char c) {
      // First char must be [a-zA-Z_].
      if (c >= 'a' && c <= 'z' || c >= 'A' && c <= 'Z' || c == '_') {
        yield return TokenState.InProgress;
      } else {
        yield return TokenState.Invalid;
        yield break;
      }

      // Every subsequent character can be [a-zA-Z0-9_].
      while (c >= 'a' && c <= 'z' || c >= 'A' && c <= 'Z' || c >= '0' && c <= '9' || c == '_') {
        yield return TokenState.InProgress;
      }

      yield return TokenState.Done;
      yield break;
    }
  }
}

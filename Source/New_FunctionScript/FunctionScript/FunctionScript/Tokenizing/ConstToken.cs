using System.Collections.Generic;
using Amadeus;
using Amadeus.Tokenizing;

namespace FunctionScript.Tokenizing {
  internal sealed class ConstToken : Token {
    internal sealed class Builder : Token.Builder {
      protected override IEnumerator<BuildState> NextChar(CharContainer c) {
        // First char must be a letter or underscore.
        if (c.Value >= 'a' && c.Value <= 'z' || c.Value >= 'A' && c.Value <= 'Z' || c.Value == '_') {
          yield return BuildState.InProgress;
        } else {
          yield return BuildState.Invalid;
          yield break;
        }

        // Every subsequent character can be a letter, number or underscore.
        while (c.Value >= 'a' && c.Value <= 'z' || c.Value >= 'A' && c.Value <= 'Z' || c.Value >= '0' && c.Value <= '9' || c.Value == '_') {
          yield return BuildState.InProgress;
        }

        yield return BuildState.Done;
        yield break;
      }

      /// <inheritdoc/>
      protected override Token CreateToken() {
        return new ConstToken(Contents.ToString(), TokenStart, TokenEnd);
      }
    }

    /// <inheritdoc/>
    public ConstToken(string content, StreamPosition tokenStart, StreamPosition tokenEnd)
      : base(content, tokenStart, tokenEnd) {}
  }
}

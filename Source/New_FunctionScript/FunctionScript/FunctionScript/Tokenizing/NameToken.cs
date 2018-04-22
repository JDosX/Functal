using System.Collections.Generic;
using Amadeus.Tokenizing;

namespace FunctionScript.Tokenizing {
  internal sealed class NameToken : Token {
    internal sealed class Builder : Token.Builder {
      protected override IEnumerator<BuildState> NextChar(CharContainer c) {
        // First char must be a letter or underscore.
        if (!IsConstStartChar(c.Value)) {
          yield break;
        } else {
          yield return BuildState.Valid;
        }

        // Every subsequent character can be a letter, number or underscore.
        while (IsConstBodyChar(c.Value)) {
          yield return BuildState.Valid;
        }
        yield break;
      }

      private bool IsConstStartChar(char c) {
        return
          c >= 'a' && c <= 'z'
          || c >= 'A' && c <= 'Z'
          || c == '_';
      }

      private bool IsConstBodyChar(char c) {
        return 
          c >= 'a' && c <= 'z'
          || c >= 'A' && c <= 'Z'
          || c >= '0' && c <= '9'
          || c == '_';
      }

      /// <inheritdoc/>
      protected override Token CreateToken() {
        return new NameToken(Contents.ToString(), TokenStart, TokenEnd);
      }
    }

    /// <inheritdoc/>
    public NameToken(string content, StreamPosition tokenStart, StreamPosition tokenEnd)
      : base(content, tokenStart, tokenEnd) {}
  }
}

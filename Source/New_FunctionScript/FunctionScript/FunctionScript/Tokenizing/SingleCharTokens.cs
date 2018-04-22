using System;
using System.Collections.Generic;
using Amadeus.Tokenizing;

namespace FunctionScript.Tokenizing {
  internal sealed class OpenParanthesesToken : SingleCharToken {
    internal sealed class Builder : SingleCharToken.Builder {
      protected override char SingleChar { get { return '('; } }
    }
  }

  internal sealed class CloseParanthesesToken : SingleCharToken {
    internal sealed class Builder : SingleCharToken.Builder {
      protected override char SingleChar { get { return ')'; } }
    }
  }

  internal sealed class CommaToken : SingleCharToken {
    internal sealed class Builder : SingleCharToken.Builder {
      protected override char SingleChar { get { return ','; } }
    }
  }

  internal sealed class PlusToken : SingleCharToken {
    internal sealed class Builder : SingleCharToken.Builder {
      protected override char SingleChar { get { return '+'; } }
    }
  }

  internal sealed class MinusToken : SingleCharToken {
    internal sealed class Builder : SingleCharToken.Builder {
      protected override char SingleChar { get { return '-'; } }
    }
  }

  internal sealed class MultToken : SingleCharToken {
    internal sealed class Builder : SingleCharToken.Builder {
      protected override char SingleChar { get { return '*'; } }
    }
  }

  internal sealed class DivideToken : SingleCharToken {
    internal sealed class Builder : SingleCharToken.Builder {
      protected override char SingleChar { get { return '/'; } }
    }
  }

  internal sealed class ModToken : SingleCharToken {
    internal sealed class Builder : SingleCharToken.Builder {
      protected override char SingleChar { get { return '%'; } }
    }
  }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public enum ValidationError
    {
        None,
        EmptyString,
        TooLongString,
        TooShortString,
        InvalidSymbols,
        InvalidDate,
        InvalidControlNumber
    }
}

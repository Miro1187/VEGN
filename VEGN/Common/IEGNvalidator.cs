using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public interface IEGNvalidator
    {
        validatinResult ValidateEGNFormat(string eGN);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using ValidationProject.Models;

namespace ValidationProject.Validators
{
    public interface ICallConnectValidator
    {
        bool Validate(CallConnectModel callConnect);
    }
}

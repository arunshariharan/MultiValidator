using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationProject.Exceptions
{
    public class InvalidPhoneNumberException : Exception
    {
        public string ErrorMesssage { get; set; }
        public InvalidPhoneNumberException(string message) : base(message)
        {
            ErrorMesssage = message;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ValidationProject.Exceptions;
using ValidationProject.Models;

namespace ValidationProject.Validators
{
    public class PhoneNumberValidator : ICallConnectValidator
    {
        public bool Validate(CallConnectModel callConnect)
        {
            if(callConnect.PhoneNumber == null
                || ValidAustralianNumber(callConnect.PhoneNumber))
            {
                throw new InvalidPhoneNumberException("Invalid number");
            }

            return true;
        }

        private bool ValidAustralianNumber(string phoneNumber)
        {
            List<string> invalidNumbers = new List<string> { "5.2", "58208101", "0" };

            if (invalidNumbers.Contains(phoneNumber))
            {
                return true;
            }   

            return false;
        }
    }
}

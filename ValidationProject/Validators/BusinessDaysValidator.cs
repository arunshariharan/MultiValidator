using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ValidationProject.Exceptions;
using ValidationProject.Models;

namespace ValidationProject.Validators
{
    public class BusinessDaysValidator : ICallConnectValidator
    {
        public bool Validate(CallConnectModel callConnect)
        {
            var businessDays = callConnect.BusinessDays;
            if (businessDays.Count == 0
                || ValidBusinessDays(businessDays))
            {
                throw new InvalidBusinessDaysException();
            }

            return true;
        }

        private bool ValidBusinessDays(List<string> businessDays)
        {
            var allowedDays = new List<string> { "Monday", "Sunday", "Friday" };
            foreach (var day in businessDays)
            {
                if (!allowedDays.Contains(day))
                {
                    return true;
                }
            }

            return false;            
        }
    }
}

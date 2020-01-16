using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationProject.Models
{
    public class CallConnectModel
    {
        public string PhoneNumber { get; set; }
        public double BusinessHoursOpening { get; set; }
        public double BusinessHoursClosing { get; set; }
        public List<string> BusinessDays { get; set; }
        public int RingTimeout { get; set; }
    }
}

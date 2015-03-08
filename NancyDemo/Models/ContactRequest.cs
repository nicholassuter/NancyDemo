using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NancyDemo.Models
{
    public class ContactRequest
    {
        public string Email { get; set; }
        public string Reason { get; set; }
        public string Details { get; set; }

        public enum ContactRequestReason
        {
           Question,
           Request
        }
    }
}
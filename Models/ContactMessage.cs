using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Artist.Models
{
    public class ContactMessage
    {
        public int Id { get; set; }

        [Display(Name = "Name:")]
        public string Name { get; set; }

        [Display(Name = "Phone Number:")]
        public string PhoneNumber { get; set; }

        [Display(Name = "E-Mail:")]
        public string EMail { get; set; }

        [Display(Name = "Your message:")]
        public string Message { get; set; }

        [Display(Name = "Where are you from ?")]
        public string Address { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Artist.Models;

namespace Artist.ViewModels
{
    public class MainViewModel
    {
        public Models.Artist Artist { get; set; }
        public List<Project> Projects { get; set; }
        public List<Category> Categories { get; set; }
        public List<Testimonial> Testimonials { get; set; }
        public List<Service> Services { get; set; }
        public List<string> IAms { get; set; }
        public ContactMessage ContactMessage { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Artist.Models;

namespace Artist.ViewModels
{
    public class PortfolioViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public Project Project { get; set; }
    }
}
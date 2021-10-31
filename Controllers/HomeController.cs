using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Artist.Models;
using Artist.ViewModels;

namespace Artist.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            var artist = _context.Artists.Find(1);
            var projects = _context.Projects.ToList();
            var categories = _context.Categories.ToList();
            var testimonials = _context.Testimonials.ToList();
            var services = _context.Services.ToList();
            var contactMessage = new ContactMessage();

            var viewModel = new MainViewModel
            {
                Artist = artist,
                Projects = projects,
                Categories = categories,
                Testimonials = testimonials,
                Services = services,
                ContactMessage = contactMessage
            };

            return View(viewModel);
        }

    }
}
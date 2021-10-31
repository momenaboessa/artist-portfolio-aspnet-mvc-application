using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Artist.Models;

namespace Artist.Controllers
{
    public class ContactMessageController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactMessageController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var contactMessages = _context.ContactMessages.ToList();
            return View(contactMessages);
        }

        public ActionResult Delete(int id)
        {
            var message = _context.ContactMessages.SingleOrDefault(m => m.Id == id);
            if (message == null)
                return HttpNotFound();

            _context.ContactMessages.Remove(message);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Save(ContactMessage contactMessage)
        {
            _context.ContactMessages.Add(contactMessage);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

    }
}
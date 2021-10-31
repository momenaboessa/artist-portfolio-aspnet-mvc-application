using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Artist.Models;

namespace Artist.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TestimonialController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: Testimonial
        public ActionResult Index()
        {
            var testimonials = _context.Testimonials.ToList();
            return View(testimonials);
        }

        public ActionResult New()
        {
            var testimonial = new Testimonial();
            return View("TestimonialForm", testimonial);
        }

        public ActionResult Edit(int id)
        {
            var testimonial = _context.Testimonials.SingleOrDefault(t => t.Id == id);
            if (testimonial == null)
                return HttpNotFound();

            return View("TestimonialForm", testimonial);
        }

        public ActionResult Delete(int id)
        {
            var testimonial = _context.Testimonials.SingleOrDefault(t => t.Id == id);
            if (testimonial == null)
                return HttpNotFound();

            var oldPath = Request.MapPath(testimonial.ImagePath);
            if (System.IO.File.Exists(oldPath))
            {
                System.IO.File.Delete(oldPath);
            }

            _context.Testimonials.Remove(testimonial);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Testimonial testimonial)
        {
            if (!ModelState.IsValid)
            {
                return View("TestimonialForm", testimonial);
            }

            if (testimonial.Id == 0)
            {
                // ----- Image ------ //
                if (testimonial.ImageFile != null)
                {
                    var imageName = Path.GetFileNameWithoutExtension(testimonial.ImageFile.FileName);
                    var extension = Path.GetExtension(testimonial.ImageFile.FileName);
                    imageName = imageName + DateTime.Now.ToString("yymmssfff") + extension;
                    testimonial.ImagePath = "~/images/testimonial/" + imageName;
                    imageName = Path.Combine(Server.MapPath("~/images/testimonial/"), imageName);
                    testimonial.ImageFile.SaveAs(imageName);
                    ModelState.Clear();
                }

                _context.Testimonials.Add(testimonial);
            }
            else
            {
                var testimonialInDb = _context.Testimonials.Single(t => t.Id == testimonial.Id);

                testimonialInDb.Name = testimonial.Name;
                testimonialInDb.FeedBack = testimonial.FeedBack;

                if (testimonial.ImageFile != null)
                {
                    // ----- Image ------ //
                    var imageName = Path.GetFileNameWithoutExtension(testimonial.ImageFile.FileName);
                    var extension = Path.GetExtension(testimonial.ImageFile.FileName);
                    imageName = imageName + DateTime.Now.ToString("yymmssfff") + extension;

                    testimonial.ImagePath = "~/images/testimonial/" + imageName;
                    imageName = Path.Combine(Server.MapPath("~/images/testimonial/"), imageName);
                    testimonial.ImageFile.SaveAs(imageName);

                    var oldPath = Request.MapPath(testimonialInDb.ImagePath);
                    if (System.IO.File.Exists(oldPath))
                    {
                        System.IO.File.Delete(oldPath);
                    }

                    testimonialInDb.ImagePath = testimonial.ImagePath;
                    ModelState.Clear();
                }
            }

            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Artist.Models;

namespace Artist.Controllers
{
    public class ServiceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServiceController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Service
        public ActionResult Index()
        {
            var services = _context.Services.ToList();
            return View(services);
        }

        public ActionResult New()
        {
            var service = new Service();
            return View("ServiceForm", service);
        }

        public ActionResult Edit(int id)
        {
            var service = _context.Services.SingleOrDefault(s => s.Id == id);
            if (service == null)
                return HttpNotFound();

            return View("ServiceForm", service);
        }

        public ActionResult Delete(int id)
        {
            var service = _context.Services.SingleOrDefault(s => s.Id == id);
            if (service == null)
                return HttpNotFound();

            var oldPath = Request.MapPath(service.ImagePath);
            if (System.IO.File.Exists(oldPath))
            {
                System.IO.File.Delete(oldPath);
            }

            _context.Services.Remove(service);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Service service)
        {
            if (!ModelState.IsValid)
            {
                return View("ServiceForm", service);
            }

            if (service.Id == 0)
            {
                // ----- Image ------ //
                if (service.ImageFile != null)
                {
                    var imageName = Path.GetFileNameWithoutExtension(service.ImageFile.FileName);
                    var extension = Path.GetExtension(service.ImageFile.FileName);
                    imageName = imageName + DateTime.Now.ToString("yymmssfff") + extension;
                    service.ImagePath = "~/images/service/" + imageName;
                    imageName = Path.Combine(Server.MapPath("~/images/service/"), imageName);
                    service.ImageFile.SaveAs(imageName);
                    ModelState.Clear();
                }

                _context.Services.Add(service);
            }
            else
            {
                var serviceInDb = _context.Services.Single(s => s.Id == service.Id);

                serviceInDb.Title = service.Title;
                serviceInDb.Description = service.Description;

                if (service.ImageFile != null)
                {
                    // ----- Image ------ //
                    var imageName = Path.GetFileNameWithoutExtension(service.ImageFile.FileName);
                    var extension = Path.GetExtension(service.ImageFile.FileName);
                    imageName = imageName + DateTime.Now.ToString("yymmssfff") + extension;

                    service.ImagePath = "~/images/service/" + imageName;
                    imageName = Path.Combine(Server.MapPath("~/images/service/"), imageName);
                    service.ImageFile.SaveAs(imageName);

                    var oldPath = Request.MapPath(serviceInDb.ImagePath);
                    if (System.IO.File.Exists(oldPath))
                    {
                        System.IO.File.Delete(oldPath);
                    }

                    serviceInDb.ImagePath = service.ImagePath;
                    ModelState.Clear();
                }
            }

            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
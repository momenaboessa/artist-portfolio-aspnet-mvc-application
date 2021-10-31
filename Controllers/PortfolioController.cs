using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.IO;
using Artist.Models;
using Artist.ViewModels;

namespace Artist.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PortfolioController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Portfolio
        public ActionResult Index()
        {
            IEnumerable<Project> projects = _context.Projects
                .Include(p => p.Category);
            return View(projects);
        }
        
        public ActionResult New()
        {
            var viewModel = new PortfolioViewModel
            {
                Categories = _context.Categories.ToList(),
                Project = new Project()
            };
            
            return View("PortfolioForm", viewModel);
        }
        
        public ActionResult Edit(int id)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);
            if (project == null)
                return HttpNotFound();

            var viewModel = new PortfolioViewModel
            {
                Project = project,
                Categories = _context.Categories.ToList()
            };
            return View("PortfolioForm", viewModel);
        }

        public ActionResult Delete(int id)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);
            if (project == null)
                return HttpNotFound();

            var oldPath = Request.MapPath(project.ImagePath);
            if (System.IO.File.Exists(oldPath))
            {
                System.IO.File.Delete(oldPath);
            }

            _context.Projects.Remove(project);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Project project)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new PortfolioViewModel
                {
                    Project = project,
                    Categories = _context.Categories.ToList()
                };
                return View("PortfolioForm", viewModel);
            }

            if (project.Id == 0)
            {
                // ----- Image ------ //
                if (project.ImageFile != null)
                {
                    var imageName = Path.GetFileNameWithoutExtension(project.ImageFile.FileName);
                    var extension = Path.GetExtension(project.ImageFile.FileName);
                    imageName = imageName + DateTime.Now.ToString("yymmssfff") + extension;
                    project.ImagePath = "~/images/portfolio/" + imageName;
                    imageName = Path.Combine(Server.MapPath("~/images/portfolio/"), imageName);
                    project.ImageFile.SaveAs(imageName);
                    ModelState.Clear();
                }
                _context.Projects.Add(project);
            }
            else
            {
                var projectInDb = _context.Projects.Single(p => p.Id == project.Id);

                projectInDb.Title = project.Title;
                projectInDb.CategoryId = project.CategoryId;

                if (project.ImageFile != null)
                {
                    // ----- Image ------ //
                    var imageName = Path.GetFileNameWithoutExtension(project.ImageFile.FileName);
                    var extension = Path.GetExtension(project.ImageFile.FileName);
                    imageName = imageName + DateTime.Now.ToString("yymmssfff") + extension;

                    project.ImagePath = "~/images/portfolio/" + imageName;
                    imageName = Path.Combine(Server.MapPath("~/images/portfolio/"), imageName);
                    project.ImageFile.SaveAs(imageName);

                    var oldPath = Request.MapPath(projectInDb.ImagePath);
                    if (System.IO.File.Exists(oldPath))
                    {
                        System.IO.File.Delete(oldPath);
                    }

                    projectInDb.ImagePath = project.ImagePath;
                    ModelState.Clear();
                }
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
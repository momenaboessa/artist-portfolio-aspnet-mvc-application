using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Artist.Models;

namespace Artist.Controllers
{
    public class ArtistController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ArtistController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Artist
        public ActionResult Index()
        {
            var artist = _context.Artists.Single(a => a.Id == 1);
            return View(artist);
        }

        public ActionResult Edit(int id)
        {
            var artist = _context.Artists.Single(a => a.Id == id);
            return View("ArtistForm", artist);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Models.Artist artist)
        {
            if (!ModelState.IsValid)
            {
                return View("ArtistForm", artist);
            }

            var artistInDb = _context.Artists.Single(a => a.Id == 1);
            artistInDb.Name = artist.Name;
            artistInDb.Address = artist.Address;
            artistInDb.PhoneNumber = artist.PhoneNumber;
            artistInDb.WorkingPeriod = artist.WorkingPeriod;

            artistInDb.HeaderText = artist.HeaderText;
            artistInDb.AboutText = artist.AboutText;
            artistInDb.PortfolioText = artist.PortfolioText;
            artistInDb.ServicesText = artist.ServicesText;
            artistInDb.TestimonialsText = artist.TestimonialsText;
            artistInDb.ContactText = artist.ContactText;

            artistInDb.FacebookLink = artist.FacebookLink;
            artistInDb.InstagramLink = artist.InstagramLink;
            artistInDb.YoutubeLink = artist.YoutubeLink;
            artistInDb.TwitterLink = artist.TwitterLink;
            artistInDb.WhatsappLink = artist.WhatsappLink;

            // ----- Hero Image ------ //
            if (artist.HeroImageFile != null)
            {
                var heroImgName = Path.GetFileNameWithoutExtension(artist.HeroImageFile.FileName);
                var heroImgExtension = Path.GetExtension(artist.HeroImageFile.FileName);
                heroImgName = heroImgName + DateTime.Now.ToString("yymmssfff") + heroImgExtension;

                artist.HeroImagePath = "~/images/bg/" + heroImgName;

                var oldHeroPath = Request.MapPath(artistInDb.HeroImagePath);
                if (System.IO.File.Exists(oldHeroPath))
                {
                    System.IO.File.Delete(oldHeroPath);
                }
                artistInDb.HeroImagePath = artist.HeroImagePath;
                heroImgName = Path.Combine(Server.MapPath("~/images/bg/"), heroImgName);
                artist.HeroImageFile.SaveAs(heroImgName);
            }

            // ----- About Image ------ //
            if (artist.AboutImageFile != null)
            {
                var aboutImgName = Path.GetFileNameWithoutExtension(artist.AboutImageFile.FileName);
                var aboutImgExtension = Path.GetExtension(artist.AboutImageFile.FileName);
                aboutImgName = aboutImgName + DateTime.Now.ToString("yymmssfff") + aboutImgExtension;

                artist.AboutImagePath = "~/images/bg/" + aboutImgName;

                var oldAboutPath = Request.MapPath(artistInDb.AboutImagePath);
                if (System.IO.File.Exists(oldAboutPath))
                {
                    System.IO.File.Delete(oldAboutPath);
                }
                artistInDb.AboutImagePath = artist.AboutImagePath;
                aboutImgName = Path.Combine(Server.MapPath("~/images/bg/"), aboutImgName);
                artist.AboutImageFile.SaveAs(aboutImgName);
            }

            ModelState.Clear();

            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
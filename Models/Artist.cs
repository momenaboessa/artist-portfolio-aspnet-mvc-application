using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Artist.Models
{
    public class Artist
    {
        // ----- Artist_Info ----- //
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Artist Name.")]
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string WorkingPeriod { get; set; }

        // ----- Headers ----- //

        [StringLength(150)]
        public string HeaderText { get; set; }

        [StringLength(600)]
        public string AboutText { get; set; }

        [StringLength(150)]
        public string PortfolioText { get; set; }

        [StringLength(150)]
        public string ServicesText { get; set; }

        [StringLength(150)]
        public string TestimonialsText { get; set; }

        [StringLength(150)]
        public string ContactText { get; set; }


        // ----- Social_Media ----- //
        public string FacebookLink { get; set; }
        public string InstagramLink { get; set; }
        public string YoutubeLink { get; set; }
        public string TwitterLink { get; set; }
        public string WhatsappLink { get; set; }


        // ----- Hero Image ----- //

        [Display(Name = "Upload Hero Image")]
        public string HeroImagePath { get; set; }

        [NotMapped]
        public HttpPostedFileBase HeroImageFile { get; set; }

        // ----- About Image ----- //

        [Display(Name = "Upload About Image")]
        public string AboutImagePath { get; set; }

        [NotMapped]
        public HttpPostedFileBase AboutImageFile { get; set; }

    }
}
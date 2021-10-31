using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Artist.Models
{
    public class Testimonial
    {
        public int Id { get; set; }

        [Required]
        [StringLength(70)]
        public string Name { get; set; }

        [Required]
        public string FeedBack { get; set; }

        // ----- Image ----- //
        [Display(Name = "Upload Client Image")]
        public string ImagePath { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

    }
}
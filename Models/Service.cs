using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Artist.Models
{
    public class Service
    {
        public int Id { get; set; }

        [Required]
        [StringLength(70)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        // ----- Image ----- //
        [Display(Name = "Upload Service Image")]
        public string ImagePath { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}
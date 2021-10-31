using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Artist.Models
{
    public class Project
    {
        public int Id { get; set; }

        [StringLength(70)]
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }


        // ----- Image ----- //
        [Display(Name = "Upload Project Image")]
        public string ImagePath { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }


    }
}
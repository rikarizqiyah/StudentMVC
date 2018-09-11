using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bootcamp_18.Models
{
    public class Major : BaseModel
    {
        public string Name { get; set; }

        //Foreign Key
        [Display(Name = "Faculty")]
        public int FacultyId { get; set; }
        [ForeignKey("FacultyId")]
        public virtual Faculty Faculties { get; set; } 
    }
}
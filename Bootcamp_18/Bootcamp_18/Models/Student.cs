using Bootcamp_18.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bootcamp_18.Models
{
    public class Student : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public int PostalCode { get; set; }   
        public string Street { get; set; }
        public double FinalScore { get; set; }

        //Foreign Key
        [Display(Name = "Major")]
        public int MajorId { get; set; }
        [ForeignKey("MajorId")]
        public virtual Major Majors { get; set; }

        [Display(Name = "Village")]
        public int VillageId { get; set; }
        [ForeignKey("VillageId")]
        public virtual Village Villages{ get; set; }
    }
}
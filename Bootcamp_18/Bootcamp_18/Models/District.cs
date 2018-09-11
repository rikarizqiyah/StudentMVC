using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bootcamp_18.Models
{
    public class District : BaseModel
    {
        public string Name { get; set; }

        //Foreign Key
        [Display(Name = "Regency")]
        public int RegencyId { get; set; }
        [ForeignKey("RegencyId")]
        public virtual Regency Regencies { get; set; }
    }
}
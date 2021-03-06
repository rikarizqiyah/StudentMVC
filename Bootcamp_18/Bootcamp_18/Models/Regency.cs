﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bootcamp_18.Models
{
    public class Regency : BaseModel
    {
        public string Name { get; set; }

        //Foreign Key
        [Display(Name = "Province")]
        public int ProvinceId { get; set; }
        [ForeignKey("ProvinceId")]
        public virtual Province Provinces { get; set; }
    }
}
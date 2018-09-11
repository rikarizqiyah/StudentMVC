﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bootcamp_18.Models
{
    public class Province : BaseModel
    {
        public string Name { get; set; }

        public ICollection<Regency> Regencies { get; set; }
    }
}
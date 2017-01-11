﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurferTech.OA.DataModel.Entites
{
    public class Page : EntityBase
    {
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string Controller { get; set; }

        [Required]
        [StringLength(20)]
        public string Action { get; set; }

        [Required]
        public bool IsDefault { get; set; }

        [JsonIgnore]
        public PageGroup Group { get; set; }
    }
}

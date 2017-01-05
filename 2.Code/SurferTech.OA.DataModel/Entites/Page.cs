using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurferTech.OA.DataModel.Entites
{
    public class Page
    {
        public int Id { get; set; }

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
        [StringLength(50)]
        public string Group { get; set; }

        [Required]
        public bool IsDefault { get; set; }
    }
}

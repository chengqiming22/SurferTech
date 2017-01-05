namespace SurferTech.OA.DataModel.DataEntites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Role
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Remark { get; set; }

        public IList<Permission> Permissions { get; set; }
    }
}

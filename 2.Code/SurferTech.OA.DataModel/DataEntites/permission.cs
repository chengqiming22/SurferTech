namespace SurferTech.OA.DataModel.DataEntites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Permission
    {
        public int Id { get; set; }

        public short Type { get; set; }

        [Required]
        public string Resource { get; set; }

        public bool IsActive { get; set; }

        public string Remark { get; set; }
    }
}

namespace SurferTech.OA.DataModel.DataEntites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("surfertech_oa_db.permission")]
    public partial class permission
    {
        public long Id { get; set; }

        public short Type { get; set; }

        [Required]
        [StringLength(50)]
        public string Resource { get; set; }

        public bool IsActive { get; set; }

        [StringLength(100)]
        public string Remark { get; set; }
    }
}

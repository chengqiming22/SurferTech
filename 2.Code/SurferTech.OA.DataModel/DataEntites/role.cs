namespace SurferTech.OA.DataModel.DataEntites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("surfertech_oa_db.role")]
    public partial class role
    {
        public long Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Remark { get; set; }
    }
}

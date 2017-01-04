namespace SurferTech.OA.DataModel.DataEntites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("surfertech_oa_db.user")]
    public partial class user
    {
        public long Id { get; set; }

        [Required]
        [StringLength(20)]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        public bool IsActive { get; set; }

        [StringLength(20)]
        public string RealName { get; set; }

        [StringLength(30)]
        public string MobileNumber { get; set; }

        [StringLength(30)]
        public string Email { get; set; }

        [StringLength(100)]
        public string Remark { get; set; }
    }
}

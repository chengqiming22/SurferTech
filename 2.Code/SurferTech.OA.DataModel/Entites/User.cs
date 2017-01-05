namespace SurferTech.OA.DataModel.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    
    public partial class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string UID { get; set; }

        [Required]
        [StringLength(20)]
        public string Password { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [StringLength(20)]
        public string RealName { get; set; }

        [StringLength(20)]
        public string MobileNumber { get; set; }

        [StringLength(20)]
        public string Email { get; set; }

        [StringLength(100)]
        public string Remark { get; set; }

        public virtual IList<Role> Roles { get; set; }
    }
}

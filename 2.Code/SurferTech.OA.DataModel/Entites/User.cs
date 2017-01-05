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
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public bool IsActive { get; set; }

        public string RealName { get; set; }

        public string MobileNumber { get; set; }

        public string Email { get; set; }

        public string Remark { get; set; }

        public IList<Role> Roles { get; set; }
    }
}

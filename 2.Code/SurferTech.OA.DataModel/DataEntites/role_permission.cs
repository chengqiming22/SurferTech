namespace SurferTech.OA.DataModel.DataEntites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("surfertech_oa_db.role_permission")]
    public partial class role_permission
    {
        public long Id { get; set; }

        public long RoleId { get; set; }

        public long PermissionId { get; set; }
    }
}

namespace SurferTech.OA.DataModel.DataEntites
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class OADbContext : DbContext
    {
        public OADbContext()
            : base("name=OADbContext")
        {
        }

        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasMany(r => r.Permissions).WithMany();
            modelBuilder.Entity<User>().HasMany(u => u.Roles).WithMany();
        }
    }
}

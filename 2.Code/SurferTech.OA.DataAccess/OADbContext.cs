namespace SurferTech.OA.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using MySql.Data.Entity;
    using SurferTech.OA.DataModel.Entites;

    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    class OADbContext : DbContext
    {
        public OADbContext()
            : base("name=OADbContext")
        {
            
        }

        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<PageGroup> PageGroups { get; set; }
        public virtual DbSet<Page> Pages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasMany(r => r.Permissions).WithMany();
            modelBuilder.Entity<User>().HasMany(u => u.Roles).WithMany();
            modelBuilder.Entity<PageGroup>().HasMany(g => g.Pages).WithOptional(p => p.Group).WillCascadeOnDelete();
        }
    }
}

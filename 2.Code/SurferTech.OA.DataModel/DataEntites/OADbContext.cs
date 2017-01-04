namespace SurferTech.OA.DataModel.DataEntites
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class OADbContext : DbContext
    {
        public OADbContext()
            : base("name=OADbContext")
        {
        }

        public virtual DbSet<permission> permissions { get; set; }
        public virtual DbSet<role> roles { get; set; }
        public virtual DbSet<role_permission> role_permission { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<user_role> user_role { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<permission>()
                .Property(e => e.Resource)
                .IsUnicode(false);

            modelBuilder.Entity<permission>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<role>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<role>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.RealName)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.MobileNumber)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.Remark)
                .IsUnicode(false);
        }
    }
}

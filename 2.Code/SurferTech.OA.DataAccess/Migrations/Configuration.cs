namespace SurferTech.OA.DataAccess.Migrations
{
    using SurferTech.OA.DataModel.Entites;
    using SurferTech.OA.DataModel.Enums;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OADbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(OADbContext context)
        {
            context.Pages.AddOrUpdate(p => p.Name,
                new Page { Name = "项目管理", Controller = "Project", Action = "Index", IsDefault = true },
                new Page { Name = "人员管理", Controller = "Employee", Action = "Index", IsDefault = true },
                new Page { Name = "财务管理", Controller = "Finance", Action = "Index", IsDefault = true });

            context.PageGroups.AddOrUpdate(g => g.Name,
                new PageGroup { Name = "项目管理" },
                new PageGroup { Name = "人员管理" },
                new PageGroup { Name = "财务管理" });

            context.Users.AddOrUpdate(u => u.UserName,
                new User { UserName = "admin", Password = "123456", IsActive = true });

            context.Roles.AddOrUpdate(r => r.Name,
                new Role { Name = "系统管理员" });

            context.SaveChanges();

            context.PageGroups.Include("Pages").First(g => g.Name == "项目管理").Pages = new List<Page> { context.Pages.First(p => p.Name == "项目管理") };
            context.PageGroups.Include("Pages").First(g => g.Name == "人员管理").Pages = new List<Page> { context.Pages.First(p => p.Name == "人员管理") };
            context.PageGroups.Include("Pages").First(g => g.Name == "财务管理").Pages = new List<Page> { context.Pages.First(p => p.Name == "财务管理") };

            context.Permissions.AddOrUpdate(p => p.ResourceId,
                new Permission { Type = (short)PermissionType.Page, ResourceId = context.Pages.First(c => c.Name == "项目管理").Id, IsActive = true },
                new Permission { Type = (short)PermissionType.Page, ResourceId = context.Pages.First(c => c.Name == "人员管理").Id, IsActive = true },
                new Permission { Type = (short)PermissionType.Page, ResourceId = context.Pages.First(c => c.Name == "财务管理").Id, IsActive = true });

            context.SaveChanges();

            context.Roles.Include("Permissions").First(r => r.Name == "系统管理员").Permissions = context.Permissions.ToList();

            context.Users.Include("Roles").First(u => u.UserName == "admin").Roles = context.Roles.ToList();

            context.SaveChanges();
        }
    }
}

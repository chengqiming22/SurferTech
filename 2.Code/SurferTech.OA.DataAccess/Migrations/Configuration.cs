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
                new Page { Name = "��Ŀ����", Controller = "Project", Action = "Index", IsDefault = true },
                new Page { Name = "��Ա����", Controller = "Employee", Action = "Index", IsDefault = true },
                new Page { Name = "�������", Controller = "Finance", Action = "Index", IsDefault = true });

            context.PageGroups.AddOrUpdate(g => g.Name,
                new PageGroup { Name = "��Ŀ����" },
                new PageGroup { Name = "��Ա����" },
                new PageGroup { Name = "�������" });

            context.Users.AddOrUpdate(u => u.UserName,
                new User { UserName = "admin", Password = "123456", IsActive = true });

            context.Roles.AddOrUpdate(r => r.Name,
                new Role { Name = "ϵͳ����Ա" });

            context.SaveChanges();

            context.PageGroups.Include("Pages").First(g => g.Name == "��Ŀ����").Pages = new List<Page> { context.Pages.First(p => p.Name == "��Ŀ����") };
            context.PageGroups.Include("Pages").First(g => g.Name == "��Ա����").Pages = new List<Page> { context.Pages.First(p => p.Name == "��Ա����") };
            context.PageGroups.Include("Pages").First(g => g.Name == "�������").Pages = new List<Page> { context.Pages.First(p => p.Name == "�������") };

            context.Permissions.AddOrUpdate(p => p.ResourceId,
                new Permission { Type = (short)PermissionType.Page, ResourceId = context.Pages.First(c => c.Name == "��Ŀ����").Id, IsActive = true },
                new Permission { Type = (short)PermissionType.Page, ResourceId = context.Pages.First(c => c.Name == "��Ա����").Id, IsActive = true },
                new Permission { Type = (short)PermissionType.Page, ResourceId = context.Pages.First(c => c.Name == "�������").Id, IsActive = true });

            context.SaveChanges();

            context.Roles.Include("Permissions").First(r => r.Name == "ϵͳ����Ա").Permissions = context.Permissions.ToList();

            context.Users.Include("Roles").First(u => u.UserName == "admin").Roles = context.Roles.ToList();

            context.SaveChanges();
        }
    }
}

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

            context.UserGroups.AddOrUpdate(u => u.Name,
                new UserGroup { Name = "admin", Remark = "超级管理员" });

            context.Users.AddOrUpdate(u => u.UserName,
                new User { UserName = "admin", Password = "AMz+TNtYabPVsjjLdeZ12squCMZubtjeUKt7TJmOjFay6XIqK+3lZwHFE42IC6o74w==", IsActive = true });

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

            context.Projects.AddOrUpdate(p => p.Name,
                new Project { Name = "一号线施工", StartDate = new DateTime(2015, 12, 18), Cooperator = "上海市政府", Status = 0, Remark = "上海轨道交通1号线（Metro Line 1 of Shanghai）是上海的第一条地铁， 亦为上海轨道交通最为繁忙、最重要的大动脉，由上海地铁第一运营有限公司负责运营。 该线于1993年1月10日建成南段（锦江乐园站至徐家汇站）上行线，于1993年5月28日开始试运营； 此后先后开通南段线路、南延伸段、北延伸段、北北延伸段。" },
                new Project { Name = "市政府大楼", StartDate = new DateTime(2015, 3, 15), Cooperator = "上海市政府", Status = 3 },
                new Project { Name = "江苏路下水道改造施工", StartDate = new DateTime(2015, 6, 5), Cooperator = "上海市政府", Status = 2, },
                new Project { Name = "五号线施工", StartDate = new DateTime(2013, 4, 11), Cooperator = "上海市政府", Status = 4 },
                new Project { Name = "十四号线施工", StartDate = new DateTime(2016, 12, 12), Cooperator = "上海市政府", Status = 1 });

            context.SaveChanges();

            context.Roles.Include("Permissions").First(r => r.Name == "系统管理员").Permissions = context.Permissions.ToList();

            context.UserGroups.Include("Roles").First(u => u.Name == "admin").Roles = context.Roles.ToList();
            context.UserGroups.Include("Users").First(u => u.Name == "admin").Users = context.Users.ToList();

            context.SaveChanges();
        }
    }
}

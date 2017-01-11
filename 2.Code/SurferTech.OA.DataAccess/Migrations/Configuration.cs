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

            context.UserGroups.AddOrUpdate(u => u.Name,
                new UserGroup { Name = "admin", Remark = "��������Ա" });

            context.Users.AddOrUpdate(u => u.UserName,
                new User { UserName = "admin", Password = "AMz+TNtYabPVsjjLdeZ12squCMZubtjeUKt7TJmOjFay6XIqK+3lZwHFE42IC6o74w==", IsActive = true });

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

            context.Projects.AddOrUpdate(p => p.Name,
                new Project { Name = "һ����ʩ��", StartDate = new DateTime(2015, 12, 18), Cooperator = "�Ϻ�������", Status = 0, Remark = "�Ϻ������ͨ1���ߣ�Metro Line 1 of Shanghai�����Ϻ��ĵ�һ�������� ��Ϊ�Ϻ������ͨ��Ϊ��æ������Ҫ�Ĵ��������Ϻ�������һ��Ӫ���޹�˾������Ӫ�� ������1993��1��10�ս����϶Σ�������԰վ����һ�վ�������ߣ���1993��5��28�տ�ʼ����Ӫ�� �˺��Ⱥ�ͨ�϶���·��������Ρ�������Ρ���������Ρ�" },
                new Project { Name = "��������¥", StartDate = new DateTime(2015, 3, 15), Cooperator = "�Ϻ�������", Status = 3 },
                new Project { Name = "����·��ˮ������ʩ��", StartDate = new DateTime(2015, 6, 5), Cooperator = "�Ϻ�������", Status = 2, },
                new Project { Name = "�����ʩ��", StartDate = new DateTime(2013, 4, 11), Cooperator = "�Ϻ�������", Status = 4 },
                new Project { Name = "ʮ�ĺ���ʩ��", StartDate = new DateTime(2016, 12, 12), Cooperator = "�Ϻ�������", Status = 1 });

            context.SaveChanges();

            context.Roles.Include("Permissions").First(r => r.Name == "ϵͳ����Ա").Permissions = context.Permissions.ToList();

            context.UserGroups.Include("Roles").First(u => u.Name == "admin").Roles = context.Roles.ToList();
            context.UserGroups.Include("Users").First(u => u.Name == "admin").Users = context.Users.ToList();

            context.SaveChanges();
        }
    }
}

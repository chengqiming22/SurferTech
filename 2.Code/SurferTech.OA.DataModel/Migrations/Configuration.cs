namespace SurferTech.OA.DataModel.Migrations
{
    using SurferTech.OA.DataModel.Entites;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SurferTech.OA.DataModel.Entites.OADbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SurferTech.OA.DataModel.Entites.OADbContext context)
        {
            context.Pages.AddOrUpdate(p => p.Name,
                new Page { Name = "��Ŀ����", Controller = "Project", Action = "Index", Group = "��Ŀ����", IsDefault = true },
                new Page { Name = "��Ա����", Controller = "Employee", Action = "Index", Group = "��Ա����", IsDefault = true },
                new Page { Name = "�������", Controller = "Finance", Action = "Index", Group = "�������", IsDefault = true });
        }
    }
}

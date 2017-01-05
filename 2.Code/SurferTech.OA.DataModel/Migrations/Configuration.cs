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
                new Page { Name = "项目管理", Controller = "Project", Action = "Index", Group = "项目管理", IsDefault = true },
                new Page { Name = "人员管理", Controller = "Employee", Action = "Index", Group = "人员管理", IsDefault = true },
                new Page { Name = "财务管理", Controller = "Finance", Action = "Index", Group = "财务管理", IsDefault = true });
        }
    }
}

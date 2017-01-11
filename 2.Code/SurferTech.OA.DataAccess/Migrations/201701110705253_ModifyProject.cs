namespace SurferTech.OA.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyProject : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "Cooperator", c => c.String(unicode: false));
            AlterColumn("dbo.Projects", "StartDate", c => c.DateTime(precision: 0));
            AlterColumn("dbo.Projects", "EndDate", c => c.DateTime(precision: 0));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Projects", "EndDate", c => c.DateTime(nullable: false, precision: 0));
            AlterColumn("dbo.Projects", "StartDate", c => c.DateTime(nullable: false, precision: 0));
            DropColumn("dbo.Projects", "Cooperator");
        }
    }
}

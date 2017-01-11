namespace SurferTech.OA.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeProjectPropertyType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Projects", "Name", c => c.String(maxLength: 20, storeType: "nvarchar"));
            AlterColumn("dbo.Projects", "Cooperator", c => c.String(maxLength: 20, storeType: "nvarchar"));
            AlterColumn("dbo.Projects", "Remark", c => c.String(maxLength: 100, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Projects", "Remark", c => c.String(unicode: false));
            AlterColumn("dbo.Projects", "Cooperator", c => c.String(unicode: false));
            AlterColumn("dbo.Projects", "Name", c => c.String(unicode: false));
        }
    }
}

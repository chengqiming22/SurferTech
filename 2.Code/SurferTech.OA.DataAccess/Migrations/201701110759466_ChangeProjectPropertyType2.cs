namespace SurferTech.OA.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeProjectPropertyType2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Projects", "Remark", c => c.String(maxLength: 1024, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Projects", "Remark", c => c.String(maxLength: 100, storeType: "nvarchar"));
        }
    }
}

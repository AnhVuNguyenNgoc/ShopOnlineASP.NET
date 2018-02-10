namespace ShopOnline.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixDB : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "CreatedBy", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "CreatedBy", c => c.String());
        }
    }
}

namespace ClothesWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatabase4h44 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Product", "IsNew", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Product", "IsNew");
        }
    }
}

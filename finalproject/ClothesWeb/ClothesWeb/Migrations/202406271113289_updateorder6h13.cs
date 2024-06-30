namespace ClothesWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateorder6h13 : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE dbo.tb_Order SET Email = 'default@example.com' WHERE Email IS NULL");

            AlterColumn("dbo.tb_Order", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_Order", "Email", c => c.String());
        }
    }
}

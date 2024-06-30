namespace ClothesWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatabase6h16 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_News", "CategoryId", "dbo.tb_Category");
            DropForeignKey("dbo.tb_Posts", "CategoryId", "dbo.tb_Category");
            DropIndex("dbo.tb_News", new[] { "CategoryId" });
            DropIndex("dbo.tb_Posts", new[] { "CategoryId" });
            RenameColumn(table: "dbo.tb_News", name: "CategoryId", newName: "Category_Id");
            RenameColumn(table: "dbo.tb_Posts", name: "CategoryId", newName: "Category_Id");
            AlterColumn("dbo.tb_News", "Category_Id", c => c.Int());
            AlterColumn("dbo.tb_Posts", "Category_Id", c => c.Int());
            AlterColumn("dbo.tb_Order", "Email", c => c.String());
            CreateIndex("dbo.tb_News", "Category_Id");
            CreateIndex("dbo.tb_Posts", "Category_Id");
            AddForeignKey("dbo.tb_News", "Category_Id", "dbo.tb_Category", "Id");
            AddForeignKey("dbo.tb_Posts", "Category_Id", "dbo.tb_Category", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_Posts", "Category_Id", "dbo.tb_Category");
            DropForeignKey("dbo.tb_News", "Category_Id", "dbo.tb_Category");
            DropIndex("dbo.tb_Posts", new[] { "Category_Id" });
            DropIndex("dbo.tb_News", new[] { "Category_Id" });
            AlterColumn("dbo.tb_Order", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.tb_Posts", "Category_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.tb_News", "Category_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.tb_Posts", name: "Category_Id", newName: "CategoryId");
            RenameColumn(table: "dbo.tb_News", name: "Category_Id", newName: "CategoryId");
            CreateIndex("dbo.tb_Posts", "CategoryId");
            CreateIndex("dbo.tb_News", "CategoryId");
            AddForeignKey("dbo.tb_Posts", "CategoryId", "dbo.tb_Category", "Id", cascadeDelete: true);
            AddForeignKey("dbo.tb_News", "CategoryId", "dbo.tb_Category", "Id", cascadeDelete: true);
        }
    }
}

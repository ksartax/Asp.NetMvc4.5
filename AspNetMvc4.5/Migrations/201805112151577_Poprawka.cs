namespace AspNetMvc4._5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Poprawka : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "Vachicle_ID", "dbo.Vachicles");
            DropIndex("dbo.Categories", new[] { "Vachicle_ID" });
            CreateTable(
                "dbo.VachicleCategories",
                c => new
                    {
                        Vachicle_ID = c.Int(nullable: false),
                        Category_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Vachicle_ID, t.Category_ID })
                .ForeignKey("dbo.Vachicles", t => t.Vachicle_ID, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.Category_ID, cascadeDelete: true)
                .Index(t => t.Vachicle_ID)
                .Index(t => t.Category_ID);
            
            DropColumn("dbo.Categories", "Vachicle_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "Vachicle_ID", c => c.Int());
            DropForeignKey("dbo.VachicleCategories", "Category_ID", "dbo.Categories");
            DropForeignKey("dbo.VachicleCategories", "Vachicle_ID", "dbo.Vachicles");
            DropIndex("dbo.VachicleCategories", new[] { "Category_ID" });
            DropIndex("dbo.VachicleCategories", new[] { "Vachicle_ID" });
            DropTable("dbo.VachicleCategories");
            CreateIndex("dbo.Categories", "Vachicle_ID");
            AddForeignKey("dbo.Categories", "Vachicle_ID", "dbo.Vachicles", "ID");
        }
    }
}

namespace AspNetMvc4._5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 250),
                        Vachicle_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Vachicles", t => t.Vachicle_ID)
                .Index(t => t.Vachicle_ID);
            
            CreateTable(
                "dbo.Types",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Vachicles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateCreated = c.DateTime(nullable: false),
                        TypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Types", t => t.TypeID, cascadeDelete: true)
                .Index(t => t.TypeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vachicles", "TypeID", "dbo.Types");
            DropForeignKey("dbo.Categories", "Vachicle_ID", "dbo.Vachicles");
            DropIndex("dbo.Vachicles", new[] { "TypeID" });
            DropIndex("dbo.Categories", new[] { "Vachicle_ID" });
            DropTable("dbo.Vachicles");
            DropTable("dbo.Types");
            DropTable("dbo.Categories");
        }
    }
}

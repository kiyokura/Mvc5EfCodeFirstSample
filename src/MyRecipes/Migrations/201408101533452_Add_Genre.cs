namespace MyRecipes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Genre : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Recipes", "Genre_Id", c => c.Int());
            CreateIndex("dbo.Recipes", "Genre_Id");
            AddForeignKey("dbo.Recipes", "Genre_Id", "dbo.Genres", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recipes", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Recipes", new[] { "Genre_Id" });
            DropColumn("dbo.Recipes", "Genre_Id");
            DropTable("dbo.Genres");
        }
    }
}

namespace MyRecipes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Foodstuffs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Foodstuffs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RecipeFoodstuffs",
                c => new
                    {
                        Recipe_Id = c.Int(nullable: false),
                        Foodstuff_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Recipe_Id, t.Foodstuff_Id })
                .ForeignKey("dbo.Recipes", t => t.Recipe_Id, cascadeDelete: true)
                .ForeignKey("dbo.Foodstuffs", t => t.Foodstuff_Id, cascadeDelete: true)
                .Index(t => t.Recipe_Id)
                .Index(t => t.Foodstuff_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecipeFoodstuffs", "Foodstuff_Id", "dbo.Foodstuffs");
            DropForeignKey("dbo.RecipeFoodstuffs", "Recipe_Id", "dbo.Recipes");
            DropIndex("dbo.RecipeFoodstuffs", new[] { "Foodstuff_Id" });
            DropIndex("dbo.RecipeFoodstuffs", new[] { "Recipe_Id" });
            DropTable("dbo.RecipeFoodstuffs");
            DropTable("dbo.Foodstuffs");
        }
    }
}

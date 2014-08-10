using System.Data.Entity;
using System.Collections.Generic;

namespace MyRecipes.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual ICollection<Foodstuff> Foodstuffs { get; set; }
    }


    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }
    }

    public class Foodstuff
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }
    }


    public class RecipesDbContext : DbContext
    {
        public RecipesDbContext()
            : base("MyRecipesConnection")
        {
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Foodstuff> Foodstuffs { get; set; }
  
    }
}

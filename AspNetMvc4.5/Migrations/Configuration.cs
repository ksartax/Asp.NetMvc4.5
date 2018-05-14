namespace AspNetMvc4._5.Migrations
{
    using Models;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Context.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Context.ApplicationDbContext context)
        {
            context.Categories.AddRange(
                new List<Category>
                {
                    new Category() { Description = "Luksusowe" },
                    new Category() { Description = "Terenowe" }
                }
            );

            context.Types.AddRange(
                new List<Models.Type>
                {
                    new Models.Type() { Description = "Skoda" }
                }
            );
        }
    }
}

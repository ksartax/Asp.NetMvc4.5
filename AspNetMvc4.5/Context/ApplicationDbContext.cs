using AspNetMvc4._5.Models;
using System.Data.Entity;

namespace AspNetMvc4._5.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Vachicle> Vechicles { get; set; }
        public DbSet<Models.Type> Types { get; set; }
        public DbSet<Category> Categories { get; set; }

        public ApplicationDbContext() : base("name=ApplicationDbContext")
        {}

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vachicle>()
                        .HasMany<Category>(s => s.Categories)
                        .WithMany(c => c.Vechicles);
        }
    }
}
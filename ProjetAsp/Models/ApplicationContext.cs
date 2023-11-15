using Microsoft.EntityFrameworkCore;

namespace ProjetAsp.Models
{
    public class ApplicationContext : DbContext 
    {
        public ApplicationContext(DbContextOptions options)
            : base(options){ }
       
        public DbSet<Categorie> Categories { get; set; }

        public DbSet<Film> Films { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>()
                .HasOne(f => f.Categorie)
                .WithMany(c => c.Films)
                .HasForeignKey(f => f.CatID)
                .OnDelete(DeleteBehavior.Cascade);
        }
        /*  protected override void OnModelCreating(DbModelBuilder modelBuilder)
          {
              // Set the default value for the UserType property
              modelBuilder.Entity<User>()
                  .Property(u => u.UserType)
                  .HasDefaultValue("user");

              base.OnModelCreating(modelBuilder);
         */
    }

    }

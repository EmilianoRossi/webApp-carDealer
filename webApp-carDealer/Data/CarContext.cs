using Microsoft.EntityFrameworkCore;
using webApp_carDealer.Models;


namespace webApp_carDealer.Data
{
    public class CarContext : DbContext
    {

        public DbSet<Car>? Cars { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Buy>? Buys { get; set; }
        public DbSet<Refile>? Refiles { get; set; }
        public DbSet<LikeCar>? Likes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Database=webApp-carDealer;Integrated Security=True");
        }


    }
}

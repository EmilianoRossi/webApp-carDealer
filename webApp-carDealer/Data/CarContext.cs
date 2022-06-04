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


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Database=webApp_car_Dealer;Integrated Security=True");
        }


    }
}
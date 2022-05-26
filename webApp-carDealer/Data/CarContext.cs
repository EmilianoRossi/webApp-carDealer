using Microsoft.EntityFrameworkCore;
using webApp_carDealer.Models;


namespace webApp_carDealer.Data
{
    public class CarContext : DbContext
    {

        public DbSet<Car> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Database=webApp-carDealer;Integrated Security=True");
        }


    }
}

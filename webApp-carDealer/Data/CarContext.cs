using Microsoft.EntityFrameworkCore;
using webApp_cardDealer.Models;

namespace webApp_carDealer.Data
{
    public class CarContext : DbContext
    {

        DbSet<Car> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Database=webApp-carDealer;Integrated Security=True");
        }


    }
}

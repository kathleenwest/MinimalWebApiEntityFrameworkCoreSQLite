using Microsoft.EntityFrameworkCore;

namespace PizzaStore.Model
{
    public class PizzaDb : DbContext
    {
        public PizzaDb(DbContextOptions options) : base(options) { }
        public DbSet<Pizza> Pizzas { get; set; } = null!;
    }
}

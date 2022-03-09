using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ContosoPizza.Models;

namespace ContosoPizza.Data;

public class PizzaContext : DbContext 
{
    public PizzaContext(DbContextOptions<PizzaContext> options) : base(options) { }


    public DbSet<Pizza> Pizzas => Set<Pizza>();
    public DbSet<Topping> Toppings => Set<Topping>();
    public DbSet<Sauce> Sauces => Set<Sauce>();
}

public class PizzaContextFactory : IDesignTimeDbContextFactory<PizzaContext>
{
    public PizzaContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<PizzaContext>();
        optionsBuilder.UseSqlite<PizzaContext>("Data Source=ContosoPizza.db");

        return new PizzaContext(optionsBuilder.Options);
    }
}

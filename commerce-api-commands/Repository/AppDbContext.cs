using commerce_api_commands.Domain;
using Microsoft.EntityFrameworkCore;

namespace commerce_api_commands.Repository;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
}
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.EntityFrameworkCore.Extensions;

namespace connect_kafka_mongodb_api.Repository;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Product>().ToCollection("Products");
    }
}

public class Product
{
    [BsonElement("id")] public Guid Id { get; set; } = new Guid();
    [BsonElement("product_description")] public string ProductDescription { get; set; } = string.Empty;
}
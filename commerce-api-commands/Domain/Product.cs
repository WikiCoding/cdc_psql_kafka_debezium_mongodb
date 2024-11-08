using System.ComponentModel.DataAnnotations;

namespace commerce_api_commands.Domain;

public class Product
{
    [Key] public Guid Id { get; set; } = new Guid();
    public string ProductDescription { get; set; } = string.Empty;
}
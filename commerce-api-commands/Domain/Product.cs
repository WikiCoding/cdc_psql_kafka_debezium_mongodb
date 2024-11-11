using System.ComponentModel.DataAnnotations;

namespace commerce_api_commands.Domain;

public class Product
{
    [Key] public int id { get; set; }
    public string product_name { get; set; } = string.Empty;
}
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace commerce_api_queries.Model;

public class Product
{
    [BsonElement("id")] public Guid Id { get; set; } = new Guid();
    [BsonElement("product_description")] public string ProductDescription { get; set; } = string.Empty;
}
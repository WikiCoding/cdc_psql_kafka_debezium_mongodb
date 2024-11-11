using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace commerce_api_queries.Model;

public class Product
{
    [BsonId] public ObjectId _Id { get; set; }
    [BsonElement("id")] public int? id { get; set; }
    [BsonElement("product_name")] public string? product_name { get; set; }
}
using commerce_api_commands.Domain;
using commerce_api_commands.Repository;
using Microsoft.AspNetCore.Mvc;

namespace commerce_api_commands.Application.CreateProductFeature;

[ApiController]
[Route("[controller]")]
public class ProductsController(AppDbContext context) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] Product product)
    {
        context.Add(product);
        return CreatedAtAction(nameof(CreateProduct), await context.SaveChangesAsync());
    }
}
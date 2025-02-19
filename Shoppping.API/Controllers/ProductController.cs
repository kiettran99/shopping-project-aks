using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Shopping.API.Data;

namespace Shoppping.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly ProductContext ProductContext;

    public ProductController(ProductContext productContext)
    {
        ProductContext = productContext;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var products = await ProductContext.Products.Find(p => true).ToListAsync();
            return Ok(products);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }

    }
}

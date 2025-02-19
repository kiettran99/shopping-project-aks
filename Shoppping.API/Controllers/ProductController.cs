using Microsoft.AspNetCore.Mvc;
using Shopping.API.Data;

namespace Shoppping.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(ProductContext.Products);
    }
}

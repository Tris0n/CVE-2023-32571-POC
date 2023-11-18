using Microsoft.AspNetCore.Mvc;
using Models;
using System.Linq.Dynamic.Core;

[Route("api")]
[ApiController]
public class ProductsController : ControllerBase
{
    [Route("products")]
    [HttpPost]
    public IActionResult Show([FromBody] ShowProducts showProducts)
    {
        var products = new List<Product>
        {
            new Product { Name = "Orange" },
            new Product { Name = "Apple" },
            new Product { Name = "Banana" }
        };

        var query = products.AsQueryable();

        if(showProducts.name != null)
        {
            var response = query.Where($"Name.Contains(\"{showProducts.name}\")");
            return new JsonResult(new { Products = response.ToArray() });
        }

        return new JsonResult(products);
    }
}
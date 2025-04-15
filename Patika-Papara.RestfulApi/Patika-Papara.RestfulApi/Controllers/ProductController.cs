using Microsoft.AspNetCore.Mvc;
using Patika_Papara.RestfulApi.Models;

namespace Patika_Papara.RestfulApi.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private static List<Product> products = new();
    private static int _nextId = 1;
    
    // GET: api/products/list?name=abc
    [HttpGet("list")]
    public IActionResult List([FromQuery] string? name)
    {
        var result = string.IsNullOrWhiteSpace(name)
            ? products
            : products.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();

        return Ok(result);
    }

    
    // GET: api/products/GetAll
    [HttpGet("GetAll")] 
    public IActionResult GetAll(){

        return Ok(products);
    }
    
    
    // GET: api/products/GetById?id=1
    [HttpGet("GetById")]
    public IActionResult GetById([FromQuery] int id)
    {
        var product = products.FirstOrDefault(p=> p.Id == id);
        if (product == null) return NotFound("Product not found");
        return Ok(product);
    }

    

    [HttpPost]
    public IActionResult Create([FromBody] Product product)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        product.Id = _nextId++;
        product.CreatedAt = DateTime.Now;
        products.Add(product);

        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);

    }

     [HttpPut]
    public IActionResult Update(int id, [FromBody] Product updatedProduct)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var product = products.FirstOrDefault(p => p.Id == id);
        if (product == null) return NotFound("Product not found");

        product.Name = updatedProduct.Name;
        product.Price = updatedProduct.Price;
        product.Description = updatedProduct.Description;

        return Ok(new { message = "Product updated successfully" });
    }
    
    
    // PATCH: api/products/1?name=NewName&price=12.40
    [HttpPatch("{id}")]
    public IActionResult Patch(int id, [FromQuery] string? name, [FromQuery] decimal? price)
    {
        var product = products.FirstOrDefault(p => p.Id == id);
        if (product == null) return NotFound(new { message = "Product not found." });

        if (name != null) product.Name = name;
        if (price.HasValue) product.Price = price.Value;

        return Ok(new { message = "Product patched successfully." });
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        var product = products.FirstOrDefault(p=>p.Id== id);
        if (product == null) return NotFound("Product not found");

        products.Remove(product);
        return Ok(new { message = "Product deleted successfully." });

    }




}
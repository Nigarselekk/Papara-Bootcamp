using HW2_RestfulApi.Interfaces;
using HW2_RestfulApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HW2_RestfulApi.Controllers;


    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("list")]
        [Authorize]
        public IActionResult List([FromQuery] string? name) => Ok(_productService.Search(name));

        [HttpGet("GetAll")]
        public IActionResult GetAll() => Ok(_productService.GetAll());

        [HttpGet("GetById")]
        public IActionResult GetById([FromQuery] int id)
        {
            var product = _productService.GetById(id);
            return product == null ? NotFound("Product not found") : Ok(product);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Product product)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var created = _productService.Create(product);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut]
        public IActionResult Update(int id, [FromBody] Product product)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return _productService.Update(id, product) ? Ok("Product updated successfully") : NotFound("Product not found");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromQuery] string? name, [FromQuery] decimal? price)
        {
            return _productService.Patch(id, name, price) ? Ok("Product patched successfully") : NotFound("Product not found");
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return _productService.Delete(id) ? Ok("Product deleted successfully") : NotFound("Product not found");
        }
    }


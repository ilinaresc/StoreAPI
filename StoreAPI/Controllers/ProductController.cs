using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreDOMAIN.Core.Entities;
using StoreDOMAIN.Core.Interfaces;
using System.Runtime.CompilerServices;

namespace StoreAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productRepository.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Product product)
        {
            var result = await _productRepository.Insert(product);
            if(!result) return BadRequest();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]Product product)
        {
            if(id != product.Id) return BadRequest();
            var result = await _productRepository.Update(product);
            if(!result) return BadRequest();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productRepository.Delete(id);
            if(!result) return BadRequest();
            return Ok(result);
        }
    }
}

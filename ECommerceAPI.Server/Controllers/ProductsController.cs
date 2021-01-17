using ECommerceApi.Core.DbModels;
using ECommerceApi.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ECommerceAPI.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var data = await _productRepository.GetProductsAsync();
          
      
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetById(int id)
        {
            var data = await _productRepository.GetProductByIdAsync(id);
            return Ok(data);
        }
        [HttpGet("getbrands")]
        public async Task<IActionResult> GetProductBrands()
        {
            var data = await _productRepository.GetProductBrandsAsync();
            return Ok(data);
        }
    }
}

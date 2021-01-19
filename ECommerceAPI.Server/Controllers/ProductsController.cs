using ECommerceApi.Core.DbModels;
using ECommerceApi.Core.Interfaces;
using ECommerceAPI.Server.Dtos;
using ECommerceAPI.Server.ValidationRules.AddDtos;
using ECommerceAPI.Server.ValidationRules.DeleteDtos;
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

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] ProductAddDto model)
        {
            var validator = new ProductAddDtoValidator();
            var result = await validator.ValidateAsync(model);
            if (result.IsValid)
            {
                await _productRepository.AddAsync(new Product
                {
                    Description = model.Description,
                    Name = model.Name,
                    ProductBrandId = model.ProductBrandId,
                    ProductTypeId = model.ProductTypeId,
                });
                var columnCount = await _productRepository.SavechangesAsync();
                columnCount = 0;
                if (columnCount == 0)
                {
                    ModelState.AddModelError("", "Bir problem ile karşılaştık");
                    return BadRequest(ModelState.Values);
                }
                return NoContent();

            }
            return BadRequest(result.Errors);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(ProductDeleteDto model)
        {
            var validator = new ProductDeleteDtoValidator();
            var result = await validator.ValidateAsync(model);
            if (result.IsValid)
            {
                var product = await _productRepository.GetAsync(p => p.Id == model.Id);
                if (product == null)
                {
                    return BadRequest("Ürün bulunamadı");
                }
                _productRepository.Remove(product);
                var columnCount = await _productRepository.SavechangesAsync();
                if (columnCount == 0)
                {

                    ModelState.AddModelError("", "Bir problem ile karşılaştık");
                    return BadRequest(ModelState.Values);
                }
                return NoContent();
            }
            return BadRequest(result.Errors);
        }

    }
}

﻿using ETicaretAPI.Application.Abstractions;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;
        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }
        [HttpGet]
        public async Task Get() 
        {
            await _productWriteRepository.AddRangeAsync(new()
            {
                new(){ Id = Guid.NewGuid(),Name = "Product 1", Price = 100, CreatedDate = DateTime.UtcNow, Stock = 10 },
                new(){ Id = Guid.NewGuid(),Name = "Product 2", Price = 200, CreatedDate = DateTime.UtcNow, Stock = 20 },
                new(){ Id = Guid.NewGuid(),Name = "Product 3", Price = 300, CreatedDate = DateTime.UtcNow, Stock = 30 },
            });
            await _productWriteRepository.SaveAsync();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id) 
        {
            Product product = await _productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }
    }
}

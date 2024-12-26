using Domain.Entities;
using Domain.Responses;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class ProductController(IProductService productService):ControllerBase
{
    [HttpGet]
    public async Task<Response<List<Product>>> GetAll() => await productService.GetAll();

    [HttpGet("{id:int}")]
    public async Task<Response<Product>> GetById(int id) => await productService.GetById(id);

    [HttpPost]
    public async Task<Response<bool>> Add(Product product) => await productService.Add(product);

    [HttpPut]
    public async Task<Response<bool>> Update(Product product) => await productService.Update(product);

    [HttpDelete]
    public async Task<Response<bool>> Delete(int id) => await productService.Delete(id);

}
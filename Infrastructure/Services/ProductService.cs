using System.Net;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class ProductService(DataContext context):IProductService
{
    public async Task<Response<List<Product>>> GetAll()
    {
        var products = await context.Products.ToListAsync();
        return new Response<List<Product>>(products);
    }

    public async Task<Response<Product>> GetById(int id)
    {
        var product = await context.Products.FirstOrDefaultAsync(p => p.Id == id);
        if (product == null)
        {
            return new Response<Product>(HttpStatusCode.NotFound, "Product not found");
        }

        return new Response<Product>(product);
    }

    public async Task<Response<bool>> Add(Product product)
    {
        await context.Products.AddAsync(product);
        var res =await context.SaveChangesAsync();
        if (res == 0)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError,"Product not created");
        }

        return new Response<bool>(true);
    }

    public async Task<Response<bool>> Update(Product product)
    {
        var product2 = await context.Products.FirstOrDefaultAsync(p => p.Id == product.Id);

        if (product2 == null)
        {
            return new Response<bool>(HttpStatusCode.NotFound, "Product not found");
        }

        product2.Name = product.Name;
        product2.Category = product.Category;
        product2.Price = product.Price;
        
        var res = await context.SaveChangesAsync();

        if (res == 0)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError,"Product not updated");
        }

        return new Response<bool>(true);
    }

    public async Task<Response<bool>> Delete(int id)
    {
        var product = await context.Products.FirstOrDefaultAsync(p => p.Id == id);
        if (product == null)
        {
            return new Response<bool>(HttpStatusCode.NotFound,"Product not found");
        }

        context.Products.Remove(product);
        var res =await context.SaveChangesAsync();

        if (res == 0)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError,"Product not found");
        }

        return new Response<bool>(true);
    }
}
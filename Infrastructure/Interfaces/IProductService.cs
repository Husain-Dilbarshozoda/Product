using Domain.Entities;
using Domain.Responses;

namespace Infrastructure.Interfaces;

public interface IProductService
{
    Task<Response<List<Product>>> GetAll();
    Task<Response<Product>> GetById(int id);
    Task<Response<bool>> Add(Product product);
    Task<Response<bool>> Update(Product product);
    Task<Response<bool>> Delete(int id);
}
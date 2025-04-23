using HW2_RestfulApi.Models;

namespace HW2_RestfulApi.Interfaces;

public interface IProductService
{
    List<Product> GetAll();
    Product? GetById(int id);
    List<Product> Search(string? name);
    Product Create(Product product);
    bool Update(int id, Product product);
    bool Patch(int id, string? name, decimal? price);
    bool Delete(int id);
}
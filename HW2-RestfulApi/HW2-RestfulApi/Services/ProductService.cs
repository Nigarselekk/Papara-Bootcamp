using HW2_RestfulApi.Interfaces;
using HW2_RestfulApi.Models;

namespace HW2_RestfulApi.Services;

public class ProductService : IProductService
{
    private readonly List<Product> _products = new();
    private int _nextId = 1;

    public List<Product> GetAll() => _products;
    public Product? GetById(int id) => _products.FirstOrDefault(p => p.Id == id);
    public List<Product> Search(string? name) => string.IsNullOrWhiteSpace(name) ? _products : _products.Where(p => p.Name.Contains(name!, StringComparison.OrdinalIgnoreCase)).ToList();
    public Product Create(Product product)
    {
        product.Id = _nextId++;
        product.CreatedAt = DateTime.Now;
        _products.Add(product);
        return product;
    }
    public bool Update(int id, Product updatedProduct)
    {
        var product = GetById(id);
        if (product == null) return false;
        product.Name = updatedProduct.Name;
        product.Price = updatedProduct.Price;
        product.Description = updatedProduct.Description;
        return true;
    }
    public bool Patch(int id, string? name, decimal? price)
    {
        var product = GetById(id);
        if (product == null) return false;
        if (name != null) product.Name = name;
        if (price.HasValue) product.Price = price.Value;
        return true;
    }
    public bool Delete(int id)
    {
        var product = GetById(id);
        if (product == null) return false;
        _products.Remove(product);
        return true;
    }
}
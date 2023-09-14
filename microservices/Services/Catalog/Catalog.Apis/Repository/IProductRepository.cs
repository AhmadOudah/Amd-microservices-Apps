using Catalog.Apis.Entities;

namespace Catalog.Apis.Repository
{
    public interface IProductRepository
    {
        Task CreateProduct(Product product);
        Task<bool> DeleteProduct(string Id);  
        Task<bool> UpdateProduct(Product product);  
        Task<Product> GetProductById(string id);
        Task<IEnumerable<Product>> GetProducts();

        Task<IEnumerable<Product>> GetProductByName(string name);

        Task<IEnumerable<Product>> GetProductCategory(string Category);
        
    }
}

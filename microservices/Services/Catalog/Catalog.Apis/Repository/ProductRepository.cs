using Catalog.Apis.Data;
using Catalog.Apis.Entities;
using MongoDB.Driver;

namespace Catalog.Apis.Repository
{
    public class ProductRepository : IProductRepository 
    {
        private readonly ICatalogContext _context;
        public ProductRepository(ICatalogContext context ) 
        {
        _context = context;
        }  
         
        public Task CreateProduct(Product product)
        {
            return _context.Products.InsertOneAsync(product);
           // throw new NotImplementedException();
        }

        public async Task<bool> DeleteProduct(string Id)
        {
             FilterDefinition<Product> filter =  Builders<Product>.Filter.Eq(p=> p.Id, Id);
            DeleteResult deleteResult =await _context.Products.DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;

        }

        public Task<Product> GetProductById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Name, name);

            return await _context.Products.Find(filter).ToListAsync();

        }

        public Task<IEnumerable<Product>> GetProductCategory(string Category)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.Find(x => true).ToListAsync();


            //throw new NotImplementedException();
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var updateResult = await _context.Products.ReplaceOneAsync(filter : g => g.Id == product.Id, replacement: product);
            return updateResult.IsAcknowledged;// && updateResult.DeletedCount > 0;

        }
    }
}

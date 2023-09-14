using Catalog.Apis.Entities;
using Catalog.Apis.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Catalog.Apis.Controllers
{
    public class CatalogController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
        [Route("api/v1/[controller]")]
        [ApiController]
        public class CatalogApiController : Controller
        {
            private readonly IProductRepository _repository;
            public CatalogApiController(ProductRepository repository) {
                _repository = repository ?? throw new ArgumentNullException(nameof(repository));    
            }

            [HttpGet]
            [ProducesResponseType(typeof(IEnumerator<Product>), (int)HttpStatusCode.OK)]
            public async Task<ActionResult<IEnumerator<Product>>> GetProducts()
            {
                var products = await _repository.GetProducts();
                return Ok(products);

            }
        }
    }
}

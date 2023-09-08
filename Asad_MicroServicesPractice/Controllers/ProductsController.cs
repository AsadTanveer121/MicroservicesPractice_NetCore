using Microsoft.AspNetCore.Mvc;
using PRODUCT_MICROSERVICES.Models;
using PRODUCT_MICROSERVICES.Repository;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Asad_MicroServicesPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductRepository _productsRepository;

         public ProductsController(IProductRepository productRepository)
        {
            _productsRepository = productRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = _productsRepository.GetProducts();
            return new OkObjectResult(products);
        }

        // i m adding the comment in the test branch 

        // i m adding the comment in the test2 branch 

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var product = _productsRepository.GetProductsByID(id);
            return new OkObjectResult(product);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Products product)
        {
            using (var scope = new TransactionScope())
            {
                _productsRepository.InsertProduct(product);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Products product)
        {
            if (product != null)
            {
                using (var scope = new TransactionScope())
                {
                    _productsRepository.UpdateProduct(product);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productsRepository.DeleteProduct(id);
            return new OkResult();
        }

    }
}

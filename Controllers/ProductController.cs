using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pagination.Models;

namespace Pagination.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private List<Products> products = new List<Products>();

        public ProductController()
        {
            // create some mock data
            for (int i = 1; i <= 100; i++)
            {
                products.Add(new Products { Id = i, Name = "Product " + i, Price = i * 2.0 });
            }
        }

        [HttpGet]
        public IEnumerable<Products> GetProducts(int page , int pageSize)
        {
            var totalProducts = products.Count;
            var totalPages = Math.Ceiling((decimal)totalProducts / pageSize);
            var productPerPage = products.Skip((page-1)*pageSize).Take(pageSize);
            return productPerPage;
        }
    }
}

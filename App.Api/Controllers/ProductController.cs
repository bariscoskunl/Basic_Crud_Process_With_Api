using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<Product> products = new();

        [HttpGet]

        public IEnumerable<Product> GetProducts()
        {
            return products;
        }

        [HttpGet("{id}")]
        public Product? GetProductsById(int id)
        {
            return products.Find(p => p.Id == id);
        }


        [HttpPost]      

        public void AddProduct(string name, decimal price, string category)
        {
            var item = new Product
            {
                Id = products.Count + 1,
                Name = name,
                Price = price,
                Category = category

            };

            products.Add(item);
        }


        [HttpPut("{id}")]
        
        public void UpdateProduct(int id, string name, decimal price, string category)
        {
            var index = products.FindIndex(x => x.Id == id);
            if (index != -1)
            {
                products[index].Name = name;
                products[index].Price = price;
                products[index].Category = category;
            }
        }

        [HttpDelete("{id}")]
        public void DeleteProduct(int id) 
        {
           var index = products.FindIndex(x => x.Id == id);
            if (index != -1)
            {
                products.RemoveAt(index);
            }

        }


    }
}

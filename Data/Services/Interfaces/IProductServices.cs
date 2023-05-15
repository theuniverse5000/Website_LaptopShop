using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.Interfaces
{
    public interface IProductServices
    {
        public bool CreateProduct(Product p);
        public bool UpdateProduct(Product p);
        public bool DeleteProduct(Guid id);
        public List<Product> GetAllProducts();
        public Product GetProductById(Guid id);
        public List<Product> GetProductByName(string name);
    }
}

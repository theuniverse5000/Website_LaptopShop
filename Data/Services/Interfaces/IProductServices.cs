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
        Task<bool>  CreateProduct(Product p);
        Task<bool> UpdateProduct(Product p, Guid id);
        Task<bool> DeleteProduct(Guid id);
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductById(Guid id);
        Task<bool> GetProductByName(string name);
    }
}

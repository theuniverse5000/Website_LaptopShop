using Data.Models;
using Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.Implements
{
    public class ProductServices : IProductServices
    {
        ApplicationDbContext context;
        public ProductServices()
        {
            context = new ApplicationDbContext();
        }

        public async Task<bool> CreateProduct(Product p)
        {
            try
            {
                if (p == null) return false;
                else
                {
                    await context.Products.AddAsync(p);
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteProduct(Guid id)
        {
            try
            {
                var product = await context.Products.FindAsync(id);
                if (product == null) return false;
                else
                {
                    context.Products.Remove(product);
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await context.Products.ToListAsync();
        }

        public async Task<Product> GetProductById(Guid id)
        {
            return await context.Products.FindAsync(id);
        }

        public async Task<bool> GetProductByName(string name)
        {
            var product = await context.Products.ToListAsync();
            var p = product.FirstOrDefault(x => x.Name == name);
            if (p == null) return false;
            else return true;
        }

        public async Task<bool> UpdateProduct(Product p, Guid id)
        {
            try
            {
                if(p == null) return false;
                else
                {
                    var product = context.Products.Find(p.Id);
                    //product.Name = p.Name;
                    product.IDManufacturer = p.IDManufacturer;
                    context.Products.Update(product);
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

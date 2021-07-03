using Microsoft.EntityFrameworkCore;
using ShopBridge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.Persistence
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext appDbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Product> AddProduct(Product product)
        {
            if (product.Category != null)
            {
                appDbContext.Entry(product.Category).State = EntityState.Unchanged;
            }

            var result = await appDbContext.Products.AddAsync(product);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteProduct(int productId)
        {
            var result = await appDbContext.Products.FirstOrDefaultAsync(p => p.ProductId == productId);

            if (result != null)
            {
                appDbContext.Products.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<Product> GetProduct(int productId)
        {
            return await appDbContext.Products
               .Include(p => p.Category)
               .FirstOrDefaultAsync(p => p.ProductId == productId);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await appDbContext.Products
                .Include(p => p.Category).ToListAsync();
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            var result = await appDbContext.Products
                .FirstOrDefaultAsync(p => p.ProductId == product.ProductId);

            if (result != null)
            {
                result.ProductName = product.ProductName;
                result.Description = product.Description;
                result.Price = product.Price;
                result.Quantity = product.Quantity;
                if (product.CategoryId != 0)
                {
                    result.CategoryId = product.CategoryId;
                }
                else if (product.Category != null)
                {
                    result.CategoryId = product.Category.CategoryId;
                }
                result.PhotoPath = product.PhotoPath;

                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}

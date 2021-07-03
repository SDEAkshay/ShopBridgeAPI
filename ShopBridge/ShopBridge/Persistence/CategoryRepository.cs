using Microsoft.EntityFrameworkCore;
using ShopBridge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.Persistence
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext appDbContext;

        public CategoryRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await appDbContext.Categories.ToListAsync();
        }

        public async Task<Category> GetCategory(int categoryId)
        {
            return await appDbContext.Categories
                .FirstOrDefaultAsync(c => c.CategoryId == categoryId);
        }
    }
}

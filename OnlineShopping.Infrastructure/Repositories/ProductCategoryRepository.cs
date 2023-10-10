using Microsoft.EntityFrameworkCore;
using OnlineShopping.Data;
using OnlineShopping.Data.Entities;
using OnlineShopping.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Infrastructure.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IList<ProductCategory>> GetAll()
        {
            return await _context.ProductCategories.ToListAsync();
        }

        public async Task<ProductCategory> GetById(int id)
        {
            return await _context.ProductCategories.FirstAsync(x => x.Id == id);
        }

        public async Task Create(ProductCategory model)
        {
            _context.ProductCategories.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task Update(ProductCategory model)
        {
            _context.Update(model);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var existItem = await this.GetById(id);
            if (existItem != null)
            {
                _context.ProductCategories.Remove(existItem);
                await _context.SaveChangesAsync();
            }
        }
    }
}

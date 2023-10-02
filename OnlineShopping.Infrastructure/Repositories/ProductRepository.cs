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
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IList<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _context.Products.FirstAsync(x => x.Id == id);
        }

        public async Task Create(Product model)
        {
            _context.Products.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Product model)
        {
            _context.Update(model);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var existItem = await this.GetById(id);
            if (existItem != null)
            {
                _context.Products.Remove(existItem);
                await _context.SaveChangesAsync();
            }
        }
    }
}

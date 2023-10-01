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
            var products = await _context.Products.ToListAsync();
            return products;
        }

        public async Task<Product> GetById(int id)
        {
            var order = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            return order;
        }

        public async Task Insert(Product model)
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
            var deleteItem = await this.GetById(id);
            if (deleteItem != null)
            {
                _context.Products.Remove(deleteItem);
                await _context.SaveChangesAsync();
            }
        }
    }
}

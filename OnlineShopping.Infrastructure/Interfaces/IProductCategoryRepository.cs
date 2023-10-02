using OnlineShopping.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Infrastructure.Interfaces
{
    public interface IProductCategoryRepository
    {
        Task<IList<ProductCategory>> GetAll();
        Task<ProductCategory> GetById(int id);
        Task Create(ProductCategory model);
        Task Update(ProductCategory model);
        Task Delete(int id);
    }
}

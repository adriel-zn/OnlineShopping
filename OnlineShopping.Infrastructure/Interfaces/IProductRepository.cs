using OnlineShopping.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Infrastructure.Interfaces
{
    public interface IProductRepository
    {
        Task<IList<Product>> GetAll();
    }
}

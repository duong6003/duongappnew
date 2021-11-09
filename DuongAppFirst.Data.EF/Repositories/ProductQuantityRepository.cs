using DuongAppFirst.Data.Entities;
using DuongAppFirst.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DuongAppFirst.Data.EF.Repositories
{
    public class ProductQuantityRepository : EFRepository<ProductQuantity, int>, IProductQuantityRepository
    {
        public ProductQuantityRepository(AppDbContext context) : base(context)
        {
        }
    }
}

using DuongAppFirst.Data.Entities;
using DuongAppFirst.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DuongAppFirst.Data.IRepositories
{
    public interface IProductCategoryRepository : IRepository<ProductCategory, int>
    {
        List<ProductCategory> GetByAlias(string alias);
    }
}

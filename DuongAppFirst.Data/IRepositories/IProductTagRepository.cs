using DuongAppFirst.Data.Entities;
using DuongAppFirst.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DuongAppFirst.Data.IRepositories
{
    public interface IProductTagRepository : IRepository<ProductTag, int>
    {
    }
}

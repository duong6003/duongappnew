using DuongAppFirst.Data.Entities;
using DuongAppFirst.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DuongAppFirst.Data.EF.Repositories
{
    public class SizeRepository : EFRepository<Size, int>, ISizeRepository
    {
        public SizeRepository(AppDbContext context) : base(context)
        {
        }
    }
}

using DuongAppFirst.Data.Entities;
using DuongAppFirst.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DuongAppFirst.Data.EF.Repositories
{
    public class FunctionRepository : EFRepository<Function, string>, IFunctionRepository
    {
        public FunctionRepository(AppDbContext context) : base(context)
        {
        }
    }
}

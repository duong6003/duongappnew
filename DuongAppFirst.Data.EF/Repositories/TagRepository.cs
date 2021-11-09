using DuongAppFirst.Data.Entities;
using DuongAppFirst.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DuongAppFirst.Data.EF.Repositories
{
    public class TagRepository : EFRepository<Tag, string>, ITagRepository
    {
        public TagRepository(AppDbContext context) : base(context)
        {
        }
    }
}

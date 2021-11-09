using DuongAppFirst.Application.ViewModels.Blog;
using DuongAppFirst.Utillities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DuongAppFirst.Application.Interfaces
{
    public interface IPageService : IDisposable
    {
        void Add(PageViewModel pageVm);

        void Update(PageViewModel pageVm);

        void Delete(int id);

        List<PageViewModel> GetAll();

        PagedResult<PageViewModel> GetAllPaging(string keyword, int page, int pageSize);

        PageViewModel GetByAlias(string alias);

        PageViewModel GetById(int id);

        void SaveChanges();

    }
}

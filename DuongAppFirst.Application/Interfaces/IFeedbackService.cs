using DuongAppFirst.Application.ViewModels.Common;
using DuongAppFirst.Utillities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DuongAppFirst.Application.Interfaces
{
    public interface IFeedbackService
    {
        void Add(FeedbackViewModel feedbackVm);

        void Update(FeedbackViewModel feedbackVm);

        void Delete(int id);

        List<FeedbackViewModel> GetAll();
        List<FeedbackViewModel> GetLastest(int top);

        PagedResult<FeedbackViewModel> GetAllPaging(string keyword, int page, int pageSize);

        FeedbackViewModel GetById(int id);

        void SaveChanges();
    }
}

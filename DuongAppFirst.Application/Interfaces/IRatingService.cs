using DuongAppFirst.Application.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DuongAppFirst.Application.Interfaces
{
    public interface IRatingService
    {
        void Add(RatingViewModel feedbackVm);

        void Update(RatingViewModel feedbackVm);

        void Delete(int id);

        List<RatingViewModel> GetAll();
        List<RatingViewModel> GetByRate(int rate, int? top);

        RatingViewModel GetById(int id);

        void SaveChanges();
    }
}

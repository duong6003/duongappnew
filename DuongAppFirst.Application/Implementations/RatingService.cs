using AutoMapper;
using AutoMapper.QueryableExtensions;
using DuongAppFirst.Application.Interfaces;
using DuongAppFirst.Application.ViewModels.Common;
using DuongAppFirst.Application.ViewModels.Product;
using DuongAppFirst.Data.Entities;
using DuongAppFirst.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DuongAppFirst.Application.Implementations
{
    public class RatingService : IRatingService
    {
        private readonly IRepository<Rating, int> _ratingRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RatingService(IRepository<Rating, int> ratingRepository, IUnitOfWork unitOfWork)
        {
            _ratingRepository = ratingRepository;
            _unitOfWork = unitOfWork;
        }

        public void Add(RatingViewModel ratingVm)
        {
            var rate = Mapper.Map<Rating>(ratingVm);
            _ratingRepository.Add(rate);
        }

        public void Delete(int id)
        {
            _ratingRepository.Remove(id);
        }

        public List<RatingViewModel> GetAll()
        {
            return _ratingRepository.FindAll().ProjectTo<RatingViewModel>().ToList();
        }
        public List<RatingViewModel> GetByRate(int rate,int? top)
        {
            var rating = _ratingRepository.FindAll(x => x.Rate == rate);
            if (top.HasValue)
            {
                return rating.Take((int)top).ProjectTo<RatingViewModel>().ToList();
            }
            else return rating.ProjectTo<RatingViewModel>().ToList();
        }

        public RatingViewModel GetById(int id)
        {
            return Mapper.Map<Rating, RatingViewModel>(_ratingRepository.FindById(id));
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(RatingViewModel ratingVm)
        {
            var rate = Mapper.Map<RatingViewModel, Rating>(ratingVm);
            _ratingRepository.Update(rate);
        }
    }
}

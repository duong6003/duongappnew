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
        private readonly IMapper _mapper;

        public RatingService(IRepository<Rating, int> ratingRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _ratingRepository = ratingRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(RatingViewModel ratingVm)
        {
            var rate = _mapper.Map<Rating>(ratingVm);
            _ratingRepository.Add(rate);
        }

        public void Delete(int id)
        {
            _ratingRepository.Remove(id);
        }

        public List<RatingViewModel> GetAll()
        {
            return _ratingRepository.FindAll().ProjectTo<RatingViewModel>(_mapper.ConfigurationProvider).ToList();
        }
        public List<RatingViewModel> GetByRate(int rate,int? top)
        {
            var rating = _ratingRepository.FindAll(x => x.Rate == rate);
            if (top.HasValue)
            {
                return rating.Take((int)top).ProjectTo<RatingViewModel>(_mapper.ConfigurationProvider).ToList();
            }
            else return rating.ProjectTo<RatingViewModel>(_mapper.ConfigurationProvider).ToList();
        }

        public RatingViewModel GetById(int id)
        {
            return _mapper.Map<Rating, RatingViewModel>(_ratingRepository.FindById(id));
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(RatingViewModel ratingVm)
        {
            var rate = _mapper.Map<RatingViewModel, Rating>(ratingVm);
            _ratingRepository.Update(rate);
        }
    }
}

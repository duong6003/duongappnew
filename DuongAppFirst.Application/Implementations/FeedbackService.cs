﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using DuongAppFirst.Application.Interfaces;
using DuongAppFirst.Application.ViewModels.Common;
using DuongAppFirst.Data.Entities;
using DuongAppFirst.Infrastructure.Interfaces;
using DuongAppFirst.Utillities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DuongAppFirst.Application.Implementations
{
    public class FeedbackService : IFeedbackService
    {
        private IRepository<Feedback, int> _feedbackRepository;
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public FeedbackService(IRepository<Feedback, int> feedbackRepository,
            IUnitOfWork unitOfWork, IMapper mapper)
        {
            _feedbackRepository = feedbackRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(FeedbackViewModel feedbackVm)
        {
            var page = _mapper.Map<FeedbackViewModel, Feedback>(feedbackVm);
            _feedbackRepository.Add(page);
        }

        public void Delete(int id)
        {
            _feedbackRepository.Remove(id);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public List<FeedbackViewModel> GetAll()
        {
            return _feedbackRepository.FindAll().ProjectTo<FeedbackViewModel>(_mapper.ConfigurationProvider).ToList();
        }

        public PagedResult<FeedbackViewModel> GetAllPaging(string keyword, int page, int pageSize)
        {
            var query = _feedbackRepository.FindAll();
            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(x => x.Name.Contains(keyword));

            int totalRow = query.Count();
            var data = query.OrderByDescending(x => x.DateCreated)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            var paginationSet = new PagedResult<FeedbackViewModel>()
            {
                Results = data.ProjectTo<FeedbackViewModel>(_mapper.ConfigurationProvider).ToList(),
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };

            return paginationSet;
        }

        public FeedbackViewModel GetById(int id)
        {
            return _mapper.Map<Feedback, FeedbackViewModel>(_feedbackRepository.FindById(id));
        }

        public List<FeedbackViewModel> GetLastest(int top)
        {
            return _feedbackRepository.FindAll().OrderByDescending(x=>x.DateModified).Take(top).ProjectTo<FeedbackViewModel>(_mapper.ConfigurationProvider).ToList();
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(FeedbackViewModel feedbackVm)
        {
            var page = _mapper.Map<FeedbackViewModel, Feedback>(feedbackVm);
            _feedbackRepository.Update(page);
        }
    }
}

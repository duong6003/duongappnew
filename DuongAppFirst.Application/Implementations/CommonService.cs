using AutoMapper;
using AutoMapper.QueryableExtensions;
using DuongAppFirst.Application.Interfaces;
using DuongAppFirst.Application.ViewModels.Common;
using DuongAppFirst.Data.Entities;
using DuongAppFirst.Infrastructure.Interfaces;
using DuongAppFirst.Utillities.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DuongAppFirst.Application.Implementations
{
    public class CommonService : ICommonService
    {
        IRepository<Footer, string> _footerRepository;
        IRepository<SystemConfig, string> _systemConfigRepository;
        IUnitOfWork _unitOfWork;
        IRepository<Slide, int> _slideRepository;
        public CommonService(IRepository<Footer, string> footerRepository,
            IRepository<SystemConfig, string> systemConfigRepository,
            IUnitOfWork unitOfWork,
            IRepository<Slide, int> slideRepository)
        {
            _footerRepository = footerRepository;
            _unitOfWork = unitOfWork;
            _systemConfigRepository = systemConfigRepository;
            _slideRepository = slideRepository;
        }

        public FooterViewModel GetFooter()
        {
            return Mapper.Map<Footer, FooterViewModel>(_footerRepository.FindSingle(x => x.Id ==
            CommonConstants.DefaultFooterId));
        }

        public List<SlideViewModel> GetSlides(string groupAlias)
        {
            return _slideRepository.FindAll(x => x.Status && x.GroupAlias == groupAlias)
                .ProjectTo<SlideViewModel>().ToList();
        }

        public SystemConfigViewModel GetSystemConfig(string code)
        {
            return Mapper.Map<SystemConfig, SystemConfigViewModel>(_systemConfigRepository.FindSingle(x => x.Id == code));
        }
    }
}

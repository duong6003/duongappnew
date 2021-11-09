using AutoMapper;
using AutoMapper.QueryableExtensions;
using DuongAppFirst.Application.Interfaces;
using DuongAppFirst.Application.ViewModels.Product;
using DuongAppFirst.Data.Entities;
using DuongAppFirst.Data.IRepositories;
using DuongAppFirst.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DuongAppFirst.Application.Implementations
{
    public class WishListService : IWishListService
    {
        private readonly IRepository<WishList, int> _wishListRepository;
        private readonly IRepository<WishListDetail, int> _wishListDetailRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public WishListService(IRepository<WishList, int> wishListRepository,
            IRepository<WishListDetail, int> wishListDetailRepository, IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _wishListRepository = wishListRepository;
            _wishListDetailRepository = wishListDetailRepository;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public List<WishListDetailViewModel> GetAllDetails(int wishId)
        {
            var wish = _wishListRepository.FindById(wishId);
            var wishVm = Mapper.Map<WishList, WishListViewModel>(wish);
            return wishVm.wishListDetails;
        }
        public void DeleteDetail(int productId, int wishId)
        {
            var detail = _wishListDetailRepository.FindSingle(x => x.ProductId == productId
           && x.WishListId == wishId);
            _wishListDetailRepository.Remove(detail);
        }
        public void Save()
        {
            _unitOfWork.Commit();
        }

        public WishListViewModel GetByUser(AppUser appUser)
        {
            var wish = _wishListRepository.FindSingle(x => x.User.Id == appUser.Id);
            if(wish == null)
            {
                wish = new WishList()
                {
                    CustomerName = appUser.FullName,
                    CustomerId = appUser.Id,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                };
                _wishListRepository.Add(wish);
                Save();
            }
            var wishVm = Mapper.Map<WishList, WishListViewModel>(wish);
            var details = _wishListDetailRepository.FindAll(x=>x.WishListId==wishVm.Id).ProjectTo<WishListDetailViewModel>().ToList();
            wishVm.wishListDetails = details;
            return wishVm;
        }
        public bool CheckProduct(WishListViewModel wishVm, int productId)
        {
            foreach(var detail in wishVm.wishListDetails) {
                if (detail.ProductId == productId) return true;
            }
            return false;
        }

        public void CreateDetail(ProductViewModel productVm, WishListViewModel wishVm)
        {
            var detail = new WishListDetail()
            {
                ProductId = productVm.Id,
                WishListId = wishVm.Id,
                Price = productVm.Price
            };
            _wishListDetailRepository.Add(detail);
        }
    }
}

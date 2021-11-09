using DuongAppFirst.Application.ViewModels.Product;
using DuongAppFirst.Data.Entities;
using DuongAppFirst.Data.Enums;
using DuongAppFirst.Utillities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DuongAppFirst.Application.Interfaces
{
    public interface IWishListService
    {
        WishListViewModel GetByUser(AppUser appUser);
        void CreateDetail(ProductViewModel productVm, WishListViewModel wishVm);
        List<WishListDetailViewModel> GetAllDetails(int wishId);
        void DeleteDetail(int productId, int wishId);
        bool CheckProduct(WishListViewModel wishVm, int productId);

        void Save();
    }
}

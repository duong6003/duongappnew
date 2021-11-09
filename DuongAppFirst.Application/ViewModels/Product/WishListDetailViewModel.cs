using System;
using System.Collections.Generic;
using System.Text;

namespace DuongAppFirst.Application.ViewModels.Product
{
    public class WishListDetailViewModel
    {
        public int Id { get; set; }
        public int WishListId { set; get; }

        public int ProductId { set; get; }
        public decimal Price { set; get; }

        public WishListViewModel WishList { set; get; }

        public ProductViewModel Product { set; get; }
    }
}

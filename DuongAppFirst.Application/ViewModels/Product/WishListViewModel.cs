using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DuongAppFirst.Application.ViewModels.Product
{
    public class WishListViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(256)]
        public string CustomerName { set; get; }
        public Guid CustomerId { set; get; }

        public List<WishListDetailViewModel> wishListDetails { get; set; }
    }
}

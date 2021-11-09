using DuongAppFirst.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DuongAppFirst.Data.Entities
{
    [Table("WishListDetails")]
    public class WishListDetail : DomainEntity<int>
    {
        public int WishListId { set; get; }

        public int ProductId { set; get; }
        public decimal Price { set; get; }

        [ForeignKey("WishListId")]
        public virtual WishList WishList { set; get; }

        [ForeignKey("ProductId")]
        public virtual Product Product { set; get; }
    }
}
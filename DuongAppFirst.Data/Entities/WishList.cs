using DuongAppFirst.Data.Enums;
using DuongAppFirst.Data.Interfaces;
using DuongAppFirst.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DuongAppFirst.Data.Entities
{
    [Table("WishLists")]
    public class WishList : DomainEntity<int>, IDateTracking
    {
        [Required]
        [MaxLength(256)]
        public string CustomerName { set; get; }
        public Guid CustomerId { set; get; }

        [ForeignKey("CustomerId")]
        public virtual AppUser User { set; get; }
        public virtual ICollection<WishListDetail> WishListDetails { get; set; }
        public DateTime DateCreated { set; get; }
        public DateTime DateModified { set; get; }
    }
}
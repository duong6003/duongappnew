using DuongAppFirst.Data.Enums;
using DuongAppFirst.Data.Interfaces;
using DuongAppFirst.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DuongAppFirst.Data.Entities
{
    public class Rating : DomainEntity<int>, ISwitchable, IDateTracking
    {
        public Rating() { }
        public Rating(Guid customerId, int? productId, string feedback, int rate, Status status, DateTime dateCreated, DateTime dateModified)
        {
            CustomerId = customerId;
            ProductId = productId;
            Feedback = feedback;
            Rate = rate;
            Status = status;
            DateCreated = dateCreated;
            DateModified = dateModified;
        }

        public Guid CustomerId { get; set; }
        public int? ProductId { get; set; }
        public string Feedback { get; set; }
        public int Rate { get; set; } = 0;
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        [ForeignKey("CustomerId")]
        public virtual AppUser User { set; get; }
        public Status Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}

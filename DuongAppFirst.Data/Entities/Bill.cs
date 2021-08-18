﻿using DuongAppFirst.Data.Enums;
using DuongAppFirst.Data.Interfaces;
using DuongAppFirst.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DuongAppFirst.Data.Entities
{
    [Table("Bills")]
    public class Bill : DomainEntity<int>, IDateTracking, ISwitchable
    {
        public Bill()
        {
        }

        public Bill(string customerName, string customerAddress, string customerMobile, string customerMessage, BillStatus billStatus,
            PaymentMethod paymentMethod, Status status, string customerId)
        {
            CustomerName = customerName;
            CustomerAddress = customerAddress;
            CustomerMobile = customerMobile;
            CustomerMessage = customerMessage;
            BillStatus = billStatus;
            PaymentMethod = paymentMethod;
            Status = status;
            CustomerId = customerId;
        }

        public Bill(int id, string customerName, string customerAddress, string customerMobile, string customerMessage, BillStatus billStatus,
            PaymentMethod paymentMethod, Status status, string customerId)
        {
            Id = id;
            CustomerName = customerName;
            CustomerAddress = customerAddress;
            CustomerMobile = customerMobile;
            CustomerMessage = customerMessage;
            BillStatus = billStatus;
            PaymentMethod = paymentMethod;
            Status = status;
            CustomerId = customerId;
        }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        [DefaultValue(Status.Active)]
        public Status Status { get; set; } = Status.Active;

        [Required]
        [MaxLength(256)]
        public string CustomerName { get; set; }

        [Required]
        [MaxLength(256)]
        public string CustomerAddress { get; set; }

        [Required]
        [MaxLength(256)]
        public string CustomerMessage { get; set; }

        [Required]
        [MaxLength(50)]
        public string CustomerMobile { get; private set; }

        public BillStatus BillStatus { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        [StringLength(450)]
        public string CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual AppUser User { get; set; }

        public virtual ICollection<BillDetail> BillDetails { get; set; }
    }
}
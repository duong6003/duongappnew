using DuongAppFirst.Application.ViewModels.Product;
using DuongAppFirst.Application.ViewModels.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace DuongAppFirst.Application.ViewModels.Common
{
    public class RatingViewModel
    {
        public int Id { get; set; }
        public Guid CustomerId { get; set; }
        public string Feedback { get; set; }
        public int? ProductId { get; set; }
        public int Rate { get; set; } = 0;
        public ProductViewModel Product { get; set; }
        public AppUserViewModel User { set; get; }
    }
}

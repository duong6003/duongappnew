using DuongAppFirst.Application.ViewModels.Common;
using DuongAppFirst.Application.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DuongAppFirst.Application.ViewModels.Blog;

namespace DuongAppFirst.Models
{
    public class HomeViewModel    {
        public List<BlogViewModel> LastestBlogs { get; set; }
        public List<SlideViewModel> HomeSlides { get; set; }
        public List<ProductViewModel> Products { get; set; }
        public List<ProductViewModel> TopRateProducts { get; set; }
        public List<ProductViewModel> TopSellProducts { get; set; }

        public List<FeedbackViewModel> TopFeedbacks { get; set; }
        public ProductViewModel PrizeGoodProduct { get; set; }

        public string Title { set; get; }
        public string MetaKeyword { set; get; }
        public string MetaDescription { set; get; }
    }
}

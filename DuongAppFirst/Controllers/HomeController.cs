using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DuongAppFirst.Models;
using Microsoft.AspNetCore.Authorization;
using DuongAppFirst.Extensions;
using DuongAppFirst.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using DuongAppFirst.Utillities.Constants;
using Newtonsoft.Json;

namespace DuongAppFirst.Controllers
{
    public class HomeController : Controller
    {
        private IProductService _productService;
        private IProductCategoryService _productCategoryService;
        private IBillService _billService;

        private IBlogService _blogService;
        private ICommonService _commonService;
        private IFeedbackService _feedbackService;

        public HomeController(IProductService productService,
            IProductCategoryService productCategoryService, 
            IBlogService blogService, 
            ICommonService commonService,
            IBillService billService,
            IFeedbackService feedbackService)
        {
            _productService = productService;
            _productCategoryService = productCategoryService;
            _blogService = blogService;
            _commonService = commonService;
            _feedbackService = feedbackService;
            _billService = billService;
        }

        public IActionResult Index(int billId = 6)
        {
            ViewData["BodyClass"] = "cms-index-index cms-home-page";
            var homeVm = new HomeViewModel();

            homeVm.Products = _productService.GetLastest(8);
            homeVm.PrizeGoodProduct = _productService.GetPrizeGood(1).FirstOrDefault();
            //TODO: top sell is temporary
            homeVm.TopSellProducts = _productService.GetLastest(5);
            homeVm.TopFeedbacks = _feedbackService.GetLastest(5);
            homeVm.LastestBlogs = _blogService.GetLastest(5);
            homeVm.TopRateProducts = _productService.GetTopRateProduct(5);
            homeVm.HomeSlides = _commonService.GetSlides("top");
            return View(homeVm);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
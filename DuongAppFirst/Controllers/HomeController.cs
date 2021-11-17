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
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Localization;

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
        private readonly IStringLocalizer<HomeController> _localizer;

        public HomeController(IProductService productService,
            IProductCategoryService productCategoryService,
            IBlogService blogService,
            ICommonService commonService,
            IBillService billService,
            IFeedbackService feedbackService, 
            IStringLocalizer<HomeController> localizer)
        {
            _productService = productService;
            _productCategoryService = productCategoryService;
            _blogService = blogService;
            _commonService = commonService;
            _feedbackService = feedbackService;
            _billService = billService;
            _localizer = localizer;
        }

        public IActionResult Index()
        {
            var title = _localizer["Tittle"];
            var culture = HttpContext.Features.Get<IRequestCultureFeature>().RequestCulture.Culture.Name;
            ViewData["BodyClass"] = "cms-index-index cms-home-page";
            var homeVm = new HomeViewModel
            {
                Products = _productService.GetLastest(8),
                PrizeGoodProduct = _productService.GetPrizeGood(1).FirstOrDefault(),
                //TODO: top sell is temporary
                TopSellProducts = _productService.GetLastest(5),
                TopFeedbacks = _feedbackService.GetLastest(5),
                LastestBlogs = _blogService.GetLastest(5),
                TopRateProducts = _productService.GetTopRateProduct(5),
                HomeSlides = _commonService.GetSlides("top")
            };
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
        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }
    }
}
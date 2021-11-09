using DuongAppFirst.Application.Interfaces;
using DuongAppFirst.Models.ProductViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuongAppFirst.Controllers
{
    public class ProductController : Controller
    {
        IProductService _productService;
        IBillService _billService;
        IProductCategoryService _productCategoryService;
        IConfiguration _configuration;

        public ProductController(IProductService productService, 
            IBillService billService, 
            IProductCategoryService productCategoryService, 
            IConfiguration configuration)
        {
            _productService = productService;
            _billService = billService;
            _productCategoryService = productCategoryService;
            _configuration = configuration;
        }

        [Route("product.html")]
        public IActionResult Index(int? pageSize, string sortBy, int page=1)
        {
            var catalog = new CatalogViewModel();
            if (pageSize == null)
                pageSize = _configuration.GetValue<int>("PageSize");

            catalog.PageSize = pageSize;
            catalog.SortType = sortBy;
            catalog.Data = _productService.GetAllPaging(null, string.Empty, page, pageSize.Value);

            return View(catalog);
        }
        [Route("{alias}-c.{id}.html")]
        public IActionResult Catalog(int id, int? pageSize, string sortBy, int page = 1)
        {
            var catalog = new CatalogViewModel();
            if (pageSize == null)
                pageSize = _configuration.GetValue<int>("PageSize");

            catalog.PageSize = pageSize;
            catalog.SortType = sortBy;
            catalog.Data = _productService.GetAllPaging(id, string.Empty, page, pageSize.Value);
            catalog.Category = _productCategoryService.GetById(id);

            return View(catalog);
        }
        [Route("search.html")]
        public IActionResult Search(string keyword, int? pageSize, string sortBy, int page = 1)
        {
            var catalog = new SearchResultViewModel();
            ViewData["BodyClass"] = "search__box__show__hide";
            if (pageSize == null)
                pageSize = _configuration.GetValue<int>("PageSize");

            catalog.PageSize = pageSize;
            catalog.SortType = sortBy;
            catalog.Data = _productService.GetAllPaging(null, keyword, page, pageSize.Value);
            catalog.Keyword = keyword;

            return View(catalog);
        }

        [Route("{alias}-p.{id}.html", Name = "ProductDetail")]
        public IActionResult Details(int id)
        {
            var model = new DetailViewModel();
            model.Product = _productService.GetById(id);
            model.Category = _productCategoryService.GetById(model.Product.CategoryId);
            model.Categories = _productCategoryService.GetAll();
            model.RelatedProducts = _productService.GetRelatedProducts(id, 4);
            model.ProductImages = _productService.GetImages(id);
            model.Ratings = _productService.GetRatings(id);
            model.Tags = _productService.GetProductTags(id);
            model.Colors = _billService.GetColors().Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
            model.Sizes = _billService.GetSizes().Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
            return View(model);
        }
    }
}

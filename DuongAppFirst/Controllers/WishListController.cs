using DuongAppFirst.Application.Interfaces;
using DuongAppFirst.Application.ViewModels.Product;
using DuongAppFirst.Data.Entities;
using DuongAppFirst.Utillities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuongAppFirst.Controllers.Components
{
    public class WishListController : Controller
    {
        private readonly IWishListService _wishListService;
        private readonly IProductService _productService;
        private readonly UserManager<AppUser> _userManager;

        public WishListController(IWishListService wishListService,
            IProductService productService,
            UserManager<AppUser> userManager)
        {
            _wishListService = wishListService;
            _productService = productService;
            _userManager = userManager;
        }

        [Route("wishlist.html", Name = "Wishlist")]
        public IActionResult Index()
        {

            return View();
        }
        #region AJAX Request
        [HttpGet]
        public IActionResult GetWishListDetails()
        {
            if (!User.Identity.IsAuthenticated) return Redirect("/login.html");
            var currentUser = _userManager.GetUserAsync(HttpContext.User).Result;
            var wishVm = _wishListService.GetByUser(currentUser);
            return new OkObjectResult(wishVm.wishListDetails);
        }
        [HttpPost]
        public IActionResult AddToWishList(int productId)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }
            else
            {
                if (!User.Identity.IsAuthenticated) return new ObjectResult(new GenericResult(false, "You are not logged in"));
                var currentUser = _userManager.GetUserAsync(HttpContext.User).Result;
                var wishVm = _wishListService.GetByUser(currentUser);
                var product = _productService.GetById(productId);
                if (_wishListService.CheckProduct(wishVm, productId))
                {
                    return new ObjectResult(new GenericResult(false, "Product already exists in Wishlist"));
                }
                else
                {
                    var detail = new WishListDetail()
                    {
                        ProductId = productId,
                        Price = product.Price,
                        WishListId = wishVm.Id,
                    };
                    _wishListService.CreateDetail(product, wishVm);
                    _wishListService.Save();
                }
                return new OkObjectResult(new GenericResult(true, "The product has been added to wishlist"));
            }
        }
        [HttpPost]
        public IActionResult RemoveFromWishList(int productId)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }
            else
            {
                var currentUser = _userManager.GetUserAsync(HttpContext.User).Result;
                var wishVm = _wishListService.GetByUser(currentUser);
                _wishListService.DeleteDetail(productId, wishVm.Id);
                _wishListService.Save();
            return new OkObjectResult(wishVm);
            }
        }
        #endregion
    }
}

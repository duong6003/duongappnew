using DuongAppFirst.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuongAppFirst.Controllers.Components
{
    public class MainMenuViewComponent : ViewComponent
    {
        private readonly IProductCategoryService _productCategoryService;

        public MainMenuViewComponent(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(_productCategoryService.GetAll());
        }
    }
}

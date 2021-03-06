using DuongAppFirst.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuongAppFirst.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Authorize]
    public class ProductController : ApiController
    {
        IProductCategoryService _productCategoryService;
        public ProductController(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }
        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult(_productCategoryService.GetAll());
        }
    }
}

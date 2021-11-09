using DuongAppFirst.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DuongAppFirst.Extensions;
using System.Security.Claims;
using DuongAppFirst.Application.ViewModels.System;
using DuongAppFirst.Utillities.Constants;

namespace DuongAppFirst.Areas.Admin.Components
{
    public class SideBarViewComponent : ViewComponent
    {
        IFunctionService _functionService;
        public SideBarViewComponent(IFunctionService functionService)
        {
            _functionService = functionService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var roles = ((ClaimsPrincipal)User).GetSpecificClaim("Roles");
            List<FunctionViewModel> functions;
            if (roles.Split(";").Contains(CommonConstants.AppRole.AdminRole))
            {
                functions = await _functionService.GetAll(string.Empty);
            }
            else
            {
                //TODO: GetbyPermission
                functions = await _functionService.GetAll(string.Empty);
            }
            return View(functions);
        }
    }
}

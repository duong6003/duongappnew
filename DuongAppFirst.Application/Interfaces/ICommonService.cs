using DuongAppFirst.Application.ViewModels.Common;
using DuongAppFirst.Application.ViewModels.Product;
using DuongAppFirst.Data.Enums;
using DuongAppFirst.Utillities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DuongAppFirst.Application.Interfaces
{
    public interface ICommonService
    {
        FooterViewModel GetFooter();
        List<SlideViewModel> GetSlides(string groupAlias);
        SystemConfigViewModel GetSystemConfig(string code);
    }
}

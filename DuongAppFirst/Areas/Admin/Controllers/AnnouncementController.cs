﻿using DuongAppFirst.Application.Interfaces;
using DuongAppFirst.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuongAppFirst.Areas.Admin.Controllers
{
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;

        public AnnouncementController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }
        [HttpGet]
        public IActionResult GetAllPaging(int page, int pageSize)
        {
            var model = _announcementService.GetAllUnReadPaging(User.GetUserId(), page, pageSize);
            return new OkObjectResult(model);
        }

        [HttpPost]
        public IActionResult MarkAsRead(string id)
        {
            var result = _announcementService.MarkAsRead(User.GetUserId(), id);
            return new OkObjectResult(result);
        }
    }
}
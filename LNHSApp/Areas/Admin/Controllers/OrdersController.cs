﻿using LNHSApp.Areas.Admin.Models.OrdersViewModels;
using LNHSApp.Contracts.BLLContracts.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LNHSApp.Areas.Admin.Controllers
{
    public class OrdersController : Controller
    {
        protected readonly IAdminDomain _adminDomain;

        public OrdersController(IAdminDomain adminDomain)
        {
            _adminDomain = adminDomain;
        }

        // GET: Admin/Orders
        public ActionResult Index()
        {
            return View();
        }

        /*[HttpGet]
        public ActionResult Create()
        {

        }

        [HttpPost]
        public ActionResult Create(BlankOrderViewModel model)
        {

        }

        [HttpGet]
        public ActionResult Edit(Guid orderId)
        {

        }

        [HttpPost]
        public ActionResult Edit(BlankOrderViewModel model)
        {

        }

        [HttpGet]
        public ActionResult Delete(Guid orderId)
        {

        }

        [HttpGet]
        public ActionResult CreateResolveOrder(Guid breakingId)
        {
            var breaking = _adminDomain.GetBreaking(breakingId);            
        }*/
    }
}
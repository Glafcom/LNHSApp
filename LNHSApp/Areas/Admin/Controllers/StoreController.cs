using AutoMapper;
using LNHSApp.Areas.Admin.Models.StoreViewModels;
using LNHSApp.Contracts.BLLContracts.Domains;
using LNHSApp.Domain.Filters;
using LNHSApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LNHSApp.Areas.Admin.Controllers
{
    public class StoreController : Controller
    {
        protected readonly IAdminDomain _adminDomain;

        public StoreController(IAdminDomain adminDomain)
        {
            _adminDomain = adminDomain;
        }

        // GET: Admin/Store
        public ActionResult Index(DetailFilter filter)
        {
            var model = new StoresViewModel
            {
                Filter = filter,
                StoresList = _adminDomain.GetStoresByFilter(filter).Select(s => Mapper.Map<StoreViewModel>(s)).ToList(),
                HockeyTablesCount = _adminDomain.GetHockeyTablesCount()
            };
            return View(model);
        }
    }
}
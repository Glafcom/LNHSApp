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
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddStores()
        {
            return View(new StoresViewModel());
        } 

        [HttpPost]
        public ActionResult AddStores(StoresViewModel model)
        {
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteStores()
        {
            return View(new StoresViewModel());
        }

        [HttpPost]
        public ActionResult DeleteStores(StoresViewModel model)
        {
            return RedirectToAction("Index");
        }



        public ActionResult Details(DetailFilter filter)
        {
            var model = new DetailsViewModel
            {
                Filter = filter,
                DetailsList = _adminDomain.GetDetailsByFilter(filter).Select(d => Mapper.Map<DetailViewModel>(d))
            };
            return View(model);
        }

        [HttpGet]
        public ActionResult AddDetail()
        {
            return View(new DetailsViewModel());
        }

        [HttpPost]
        public ActionResult AddDetail(DetailViewModel model)
        {
            _adminDomain.AddDetail(Mapper.Map<Detail>(model));
            return RedirectToAction("Details");
        }

        [HttpGet]
        public ActionResult EditDetail(Guid detailId)
        {
            var model = _adminDomain.GetDetail(detailId);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditDetail(DetailViewModel model)
        {
            _adminDomain.ChangeDetail(Mapper.Map<Detail>(model));
            return RedirectToAction("Details");
        }

        [HttpGet]
        public ActionResult DeleteDetail(Guid detailId)
        {
            _adminDomain.DeleteDetail(detailId);
            return RedirectToAction("Details");
        }
    }
}
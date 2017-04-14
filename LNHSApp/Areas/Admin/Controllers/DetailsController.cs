using AutoMapper;
using LNHSApp.Areas.Admin.Models.DetailsViewModels;
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
    public class DetailsController : Controller
    {
        protected readonly IAdminDomain _adminDomain;

        public DetailsController(IAdminDomain adminDomain)
        {
            _adminDomain = adminDomain;
        }

        // GET: Admin/Details
        public ActionResult Index(DetailFilter filter)
        {
            var model = new DetailsViewModel
            {
                Filter = filter,
                DetailsList = _adminDomain.GetDetailsByFilter(filter).Select(d => Mapper.Map<DetailViewModel>(d)).ToList()
            };
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new DetailViewModel());
        }

        [HttpPost]
        public ActionResult Create(DetailViewModel model)
        {
            _adminDomain.AddDetail(Mapper.Map<Detail>(model));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(Guid detailId)
        {
            var model = _adminDomain.GetDetail(detailId);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(DetailViewModel model)
        {
            _adminDomain.ChangeDetail(Mapper.Map<Detail>(model));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(Guid detailId)
        {
            _adminDomain.DeleteDetail(detailId);
            return RedirectToAction("Index");
        }
    }
}
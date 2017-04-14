using AutoMapper;
using LNHSApp.Areas.Admin.Models.BreakingsViewModels;
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
    public class BreakingsController : Controller
    {
        protected readonly IAdminDomain _adminDomain;

        public BreakingsController(IAdminDomain adminDomain)
        {
            _adminDomain = adminDomain;
        }

        // GET: Admin/Breakings
        public ActionResult Index(BreakingFilter filter)
        {
            var model = new BreakingsViewModel
            {
                Filter = filter,
                BreakingsList = _adminDomain.GetBreakingsbyFilter(filter).Select(b => Mapper.Map<BreakingViewModel>(b)).ToList()
            };
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.HockeyTablesList = _adminDomain.GetHockeyTables()
                .Select(ht => new SelectListItem { Value = ht.Id.ToString(), Text = $"{ht.Code} ({ht.Model})" });
            ViewBag.DetailsList = _adminDomain.GetDetails()
                .Select(d => new SelectListItem { Value = d.Id.ToString(), Text = $"({d.Code}) {d.Name}" });
            return View(new BlankBreakingViewModel());
        }

        [HttpPost]
        public ActionResult Create(BlankBreakingViewModel model)
        {
            _adminDomain.CreateBreaking(Mapper.Map<Breaking>(model));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(Guid breakingId)
        {
            ViewBag.HockeyTablesList = _adminDomain.GetHockeyTables()
                .Select(ht => new SelectListItem { Value = ht.Id.ToString(), Text = $"{ht.Code} ({ht.Model})" });
            ViewBag.DetailsList = _adminDomain.GetDetails()
                .Select(d => new SelectListItem { Value = d.Id.ToString(), Text = $"({d.Code}) {d.Name}" });
            var model =  Mapper.Map<BlankBreakingViewModel>(_adminDomain.GetBreaking(breakingId));
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(BlankBreakingViewModel model)
        {
            _adminDomain.EditBreaking(Mapper.Map<Breaking>(model));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(Guid breakingId)
        {
            _adminDomain.DeleteBreaking(breakingId);
            return RedirectToAction("Index");
        }

    }
}
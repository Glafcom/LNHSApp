using AutoMapper;
using LNHSApp.Areas.Admin.Models.TablesViewModels;
using LNHSApp.Contracts.BLLContracts.Domains;
using LNHSApp.Domain.Enums;
using LNHSApp.Domain.Filters;
using LNHSApp.Domain.Models;
using LNHSApp.Extensions.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LNHSApp.Areas.Admin.Controllers
{
    public class TablesController : Controller
    {
        protected readonly IAdminDomain _adminDomain;

        public TablesController(IAdminDomain adminDomain)
        {
            _adminDomain = adminDomain;
        }

        // GET: Admin/Tables
        public ActionResult Index(HockeyTableFilter filter)
        {
            var model = new HockeyTablesViewModel
            {
                Filter = filter,
                HockeyTablesList = _adminDomain.GetHockeyTablesByFilter(filter).Select(ht => Mapper.Map<HockeyTableViewModel>(ht)).ToList()
            };
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.TableConditionsList = EnumHelper.GetEnumDictionary<TableCondition>()
                .Select(tc => new SelectListItem { Value = tc.Key.ToString(), Text = tc.Value });
            ViewBag.UsersList = _adminDomain.GetUsers()
                .Select(u => new SelectListItem { Value = u.Id.ToString(), Text = $"{u.Name} {u.Surname}" });
            return View(new BlankHockeyTableViewModel());
        }

        [HttpPost]
        public ActionResult Create(BlankHockeyTableViewModel model)
        {
            _adminDomain.AddHockeyTable(Mapper.Map<HockeyTable>(model));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(Guid hockeyTableId)
        {
            ViewBag.TableConditionsList = EnumHelper.GetEnumDictionary<TableCondition>()
                .Select(tc => new SelectListItem { Value = tc.Key.ToString(), Text = tc.Value });
            ViewBag.UsersList = _adminDomain.GetUsers()
                .Select(u => new SelectListItem { Value = u.Id.ToString(), Text = $"{u.Name} {u.Surname}" });

            var model = Mapper.Map<BlankHockeyTableViewModel>(_adminDomain.GetHockeyTable(hockeyTableId));
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(BlankHockeyTableViewModel model)
        {
            _adminDomain.ChangeHockeyTable(Mapper.Map<HockeyTable>(model));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(Guid hockeyTableId)
        {
            _adminDomain.DeleteHockeyTable(hockeyTableId);
            return RedirectToAction("Index");
        }
    }
}
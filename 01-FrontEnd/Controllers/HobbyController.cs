using Common;
using Model.Domain;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    public class HobbyController : Controller
    {
        private readonly IHobbyService _hobbyService = DependecyFactory.GetInstance<IHobbyService>();
        // GET: Hobby
        public ActionResult Index()
        {
            return View(
                    _hobbyService.GetAll()
                );
        }

        public ActionResult New() {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Hobby model)
        {
            _hobbyService.Insert(model);
            return RedirectToAction("Index");
        }

        public ActionResult Deleted(int id)
        {
            _hobbyService.Deleted(id);
            return  RedirectToAction("Index");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RL.Entity.Own;
using RL.OwnData.Contract.Infrastructure;

namespace RL.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IUnitOfWork unitOfWork)
        {
            var safeRepo = unitOfWork.SafeRemoveRepository<User>();
            var hardRepo = unitOfWork.HardRemoveRepository<User>();

            safeRepo.Insert(new User());
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using RL.DataProcessing.Contract.Infrastructure;
using RL.Entity.Own;

namespace RL.Web.Controllers
{
    public class BaseController : Controller
    {
        private ApplicationUserManager _manager;
        protected IUnitOfWork UnitOfWork;

        public BaseController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        protected ApplicationUserManager UserManager
        {
            get
            {
                return _manager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            set
            {
                _manager = value;
            }
        }

        protected User CurrentUser
        {
            get
            {
                var userId = User.Identity.GetUserId();
                return UnitOfWork.GetUser(userId);
            }
        }
    }
}
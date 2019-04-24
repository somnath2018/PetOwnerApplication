namespace PetOwnerApplication.Controllers
{
    using System.Web.Mvc;
    using Services;

    public class BaseController : Controller
    {
        public BaseController()
        {
        }

        public ViewResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}
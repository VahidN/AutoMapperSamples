using System.Web.Mvc;
using AutoMapper;
using Sample12.Models;
using Sample12.ViewModels;

namespace Sample12.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new UserModel { FirstName = "و", Id = 1, LastName = "ن" };
            var viewModel = Mapper.Map<UserViewModel>(model);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(UserViewModel data)
        {
            return View(data);
        }
    }
}
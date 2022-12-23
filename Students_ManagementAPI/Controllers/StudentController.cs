using Microsoft.AspNetCore.Mvc;
using StudentAppCore.Core.IServices;

namespace Students_ManagementAPI.Controllers
{
    public class StudentController : Controller
    {
        private IServices _Iservice;

        public StudentController(IServices Iservices)
        {
            _Iservice = Iservices;
        }
        public IActionResult Index()
        {
            return View();
        }


        #region

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserLogin model)
        {
            userLogin newuser = _Iservice.newuser(model);
            if(newuser.IsAdmin==true)
            {


            }

        }
    }
}
        #endregion








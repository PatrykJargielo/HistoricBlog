using System.Web.Mvc;
using HistoricBlog.BLL.Logger;
using HistoricBlog.BLL.Posts;
using HistoricBlog.BLL.Users;
using HistoricBlog.DAL.Users;

namespace HistoricBlog.Web.Controllers
{
    public class HomeController : Controller
    {
 
     

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        //public ActionResult CreateAdminUser(UserViewModels User)
        //{

        //    //User map to entity

        //    var user = new User();

        //    var userResult = UserService.Create(user);

        //    if (!userResult.IsVaild)
        //    {
        //        // do widoku jakii blad userResult.Message
        //        return View();
        //    }

        //    var userResult2 =  RolesService.AddRoleToService(RolesService, user);

        //    if (!userResult.IsVaild)
        //    {
        //        // do widoku jakii blad userResult2.Message
        //        return View();
        //    }


        //    ViewBag.Message = "konto admina jest.";

        //    return View();
        //}

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            //log.Error("Sprawdzenie czy loguje kontakty");
            return View();
        }
    }
}
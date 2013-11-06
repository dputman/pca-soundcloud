using System.Web.Mvc;

namespace PcaSoundCloud.Web.Controllers
{
    public class HomeController : DefaultController
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }
    }
}

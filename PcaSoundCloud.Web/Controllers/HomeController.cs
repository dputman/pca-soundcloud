using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using PcaSoundCloud.API;

namespace PcaSoundCloud.Web.Controllers
{
    public class HomeController : DefaultController
    {
        //
        // GET: /User/

        public ActionResult Index(string access_token, string scope)
        {
            this.HttpContext.Session.Add("token", access_token);
            var _service = new UserApi(new MusicService());
            var me = _service.GetUserByAccessToken(access_token);
            this.HttpContext.Session.Add("username", me.username);
            return View(me);
        }
    }
}

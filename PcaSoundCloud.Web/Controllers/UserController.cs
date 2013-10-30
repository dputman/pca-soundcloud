using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using PcaSoundCloud.API;

namespace PcaSoundCloud.Web.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index(string accessToken, string scope)
        {
            this.HttpContext.Session.Add("token", accessToken);
            var _service = new SoundCloudService(new MusicService());
            var me = _service.GetUserByAccessToken(accessToken);
            
            return View(me);
        }
    }
}

using System.Web.Mvc;
using PcaSoundCloud.API;

namespace PcaSoundCloud.Web.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index(string token)
        {
            SoundCloudService _service = new SoundCloudService(new MusicService());
            //var user = _service.GetUser();
            
            return View();
        }
    }
}

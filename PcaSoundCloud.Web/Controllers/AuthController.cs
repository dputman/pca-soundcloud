using System.Text;
using System.Web;
using System.Web.Mvc;
using Castle.MicroKernel.SubSystems.Conversion;

namespace PcaSoundCloud.Web.Controllers
{
    public class AuthController : Controller
    {

        private const string ClientId = "c49610f852b5967ec6df11d4d53d71b4";
        private const string ClientSecret = "7707d3433572cc5591fe295b85b3e385";
        private const string AppName = "PcaSoundCloudApp";


        private const string TestToken = "1-55455-62452880-fe694f0d2b2f7fa";
        //soundcloud username: Pca-SoundCloud-User
        //soundcloud password: agileLIVE!
        //app name: PcaSoundCloudApp
        //client id: c49610f852b5967ec6df11d4d53d71b4
        //client secret: 7707d3433572cc5591fe295b85b3e385
        //https://soundcloud.com/connect
        //https://api.soundcloud.com/oauth2/token


        public ActionResult Connect()
        {
            const string redirectUrl = "http://127.0.0.1:1234/auth/complete";
            var url =
                string.Format(
                    "https://soundcloud.com/connect?client_id={0}&response_type=token&scope=non-expiring&display=next&redirect_uri={1}", ClientId, redirectUrl);

            
            return Redirect(url);
        }

        public ActionResult Complete()
        {
            return View();
        }

        public ActionResult CompleteRedirect(string access_token, string scope)
        {
            return Content(access_token + ' ' + scope);
        }
    }
}
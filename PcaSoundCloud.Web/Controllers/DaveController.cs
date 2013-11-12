using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Web;
using System.Web.Mvc;
using PcaSoundCloud.Core;
using PcaSoundCloud.Web.Models;

namespace PcaSoundCloud.Web.Controllers
{
    public class DaveController : Controller
    {
        //
        // GET: /Dave/

        public ActionResult Index(int userId)
        {
//	        var favorites = new TrackService().GetFavoriteTracksByUserId(userId);
//	        var model = new UserModel {Favorites = favorites};
//            return View(model);
            return null;
        }
    }
}

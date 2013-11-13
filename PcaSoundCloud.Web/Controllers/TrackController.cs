using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PcaSoundCloud.Core;
using PcaSoundCloud.Shared;

namespace PcaSoundCloud.Web.Controllers
{
    public class TrackController : Controller
    {
        private readonly ITrackService _trackService;

        public TrackController(ITrackService trackService)
        {
            _trackService = trackService;            
        }

        //
        // GET: /Track/

        public ActionResult Index(int i)
        {            
            return View(_trackService.GetTrack(i));
        }
    }
}

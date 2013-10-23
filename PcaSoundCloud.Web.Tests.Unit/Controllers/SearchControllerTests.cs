using Moq;
using NUnit.Framework;
using PcaSoundCloud.Shared;
using PcaSoundCloud.Web.Controllers;

namespace PcaSoundCloud.Web.Tests.Unit.Controllers
{
    public class SearchControllerTests
    {
        [Test]
        public void search_music_should_call_track_service_search_method()
        {
            //var service = new Mock<ITrackService>();

            //service.Setup(s => s.Search(It.IsAny<string>())).Verifiable();
            
            //var controller = new SearchController(service.Object);
            //controller.searchMusic("test");
            //service.VerifyAll();
        }



    }
}

using System.Collections.Generic;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using PcaSoundCloud.Shared;
using PcaSoundCloud.Shared.Entities;
using PcaSoundCloud.Web.Controllers;

namespace PcaSoundCloud.Web.Tests.Functional.Controllers
{
    [TestFixture]
    public class SearchControllerTests
    {
        //[Test] // will fail
        //public void CanResolve()
        //{
        //    var container = new WindsorContainer()
        //        .Install(new ControllerInstaller())
        //        .Install(new ServiceInstaller());

        //    var controller = container.Resolve<SearchController>();
        //    Assert.That(controller, Is.Not.Null);
        //}

        [Test]
        public void can_search_for_music()
        {
            var trackService = new Mock<ITrackService>();
            var tracks = new List<Track>
                {
                    new Track
                        {
                            Id = "1",
                            Title = "a track!",
                            Description = "1 track"
                        }
                };
            trackService.Setup((service) => service.Search(It.IsAny<TrackCriteria>()))
                        .Returns(() => tracks);

            var controller = new SearchController(trackService.Object);
            var result = controller.SearchMusic("a song name");
            Assert.That(result.GetType(), Is.EqualTo(typeof(JsonResult)));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using PcaSoundCloud.Shared;
using PcaSoundCloud.Shared.Entities;
using PcaSoundCloud.Web.Controllers;

namespace PcaSoundCloud.Web.Tests.Unit.Controllers
{
    class TrackControllerTests
    {
        [Test]
        public void IndexShouldGetTrackFromId()
        {
            var expectedTrack = new Track();
            var trackService = new Mock<ITrackService>();
            trackService.Setup(mock => mock.GetTrack(1234)).Returns(expectedTrack);            
            var controller = new TrackController(trackService.Object);
            
           var result = controller.Index(1234) as ViewResult;
           Assert.That(result.Model, Is.SameAs(expectedTrack));
        }
    }
}

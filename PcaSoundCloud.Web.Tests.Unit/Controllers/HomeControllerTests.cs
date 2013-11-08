using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using PcaSoundCloud.API;
using PcaSoundCloud.Core;
using PcaSoundCloud.Shared;
using PcaSoundCloud.Shared.Entities;
using PcaSoundCloud.Web.Controllers;

namespace PcaSoundCloud.Web.Tests.Unit.Controllers
{
    class HomeControllerTests
    {
        [Test]
        public void GetPopularTracks()
        {
            List<Track> tracks1 = new List<Track>();
            List<Track> tracks2 = new List<Track>();
            List<Track> tracks3 = new List<Track>();
            tracks1.Add(new Track());
            tracks2.Add(new Track());
            tracks3.Add(new Track());

            Mock<ITrackService> trackMock = new Mock<ITrackService>();
            trackMock.Setup(sut => sut.GetFavoriteTracksByUserId(1)).Returns(tracks1).Verifiable();
            trackMock.Setup(sut => sut.GetFavoriteTracksByUserId(2)).Returns(tracks2).Verifiable();
            trackMock.Setup(sut => sut.GetFavoriteTracksByUserId(3)).Returns(tracks3).Verifiable();
            

            HomeController controller = new HomeController(trackMock.Object, null);
            var actual = controller.GetPopularTracks(new List<int>() {1,2,3});

            List<Track> expected = new List<Track>();
            expected.AddRange(tracks1);
            expected.AddRange(tracks2);
            expected.AddRange(tracks3);
        
            Assert.That(expected, Is.EqualTo(actual));
            
            trackMock.VerifyAll();
        }
    }
}

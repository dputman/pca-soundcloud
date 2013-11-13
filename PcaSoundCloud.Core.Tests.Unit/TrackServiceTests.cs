using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PcaSoundCloud.API;
using PcaSoundCloud.Shared;
using PcaSoundCloud.Shared.Entities;

namespace PcaSoundCloud.Core.Tests.Unit
{
    public class TrackServiceTests
    {
        private TrackService _trackService;
        private Mock<ITrackApi> _trackApi;

        [SetUp]
        public void Setup()
        {
            _trackApi = new Mock<ITrackApi>();
            _trackService = new TrackService(_trackApi.Object);
        }

        [Test]
        public void IsAnITrackService()
        {
            Assert.That(_trackService, Is.InstanceOf<ITrackService>());
        }

        
        [Test]
        public void CanUseSearchService()
        {
            var expect = new List<Track> {new Track()};
            var criteria = new TrackCriteria {SearchText = "stuff", MaxResults = 5};
            _trackApi.Setup(mock => mock.Search(criteria)).Returns(expect);
            var tracks = _trackService.Search(criteria);
            Assert.That(tracks, Is.EqualTo(expect));
        }

	    [Test]
	    public void CanSearchByUserNameForFavoriteTracks()
	    {
            var expect = new List<Track> { new Track() };
            _trackApi.Setup(mock => mock.GetFavoriteTracksByUserId(7)).Returns(expect);
            var tracks = _trackService.GetFavoriteTracksByUserId(7);
            Assert.That(tracks, Is.EqualTo(expect));
	    }

        [Test]
        public void GetTrackReturnsTrack()
        {
            var expected = new Track();
            _trackApi.Setup(mock => mock.GetTrack(1234)).Returns(expected);

            var actual = _trackService.GetTrack(1234);
            Assert.That(actual, Is.SameAs(expected));
        }

    }
}

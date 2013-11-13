using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PcaSoundCloud.Shared;
using PcaSoundCloud.Shared.Entities;
using RestSharp;

namespace PcaSoundCloud.API.Tests.Unit
{
    public class TrackApiTests
    {
        private TrackApi _trackApi;
        private Mock<IMusicService> _musicService;

        [SetUp]
        public void Setup()
        {
            _musicService = new Mock<IMusicService>();
            _trackApi = new TrackApi(_musicService.Object);
        }

        [Test]
        public void IsAnITrackService()
        {
            Assert.That(_trackApi, Is.InstanceOf<ITrackApi>());
        }


        [Test]
        public void SearchReturnsTracksFromMusicService()
        {
            var expectedTracks = new List<Track> {new Track()};
            _musicService.Setup(mock => mock.CallMusicService<List<Track>>(It.IsAny<RestRequest>()))
                .Returns(expectedTracks);
            var tracks = _trackApi.Search(new TrackCriteria());
            Assert.That(tracks, Is.SameAs(expectedTracks));
        }

        [Test]
        public void CanSearchByUserNameForFavoriteTracks()
        {
            var expectedTracks = new List<Track> {new Track()};
            _musicService.Setup(mock => mock.CallMusicService<List<Track>>(It.IsAny<RestRequest>()))
                .Returns(expectedTracks);
            var tracks = _trackApi.GetFavoriteTracksByUserId(6);
            Assert.That(tracks, Is.SameAs(expectedTracks));
        }

        [Test]
        public void GetTrackFetchesTrackFromSoundCloud()
        {
            var expectedTrack = new Track();
            _musicService.Setup(mock => mock.CallMusicService<Track>(It.IsAny<RestRequest>()))
                .Returns(expectedTrack);
            var track = _trackApi.GetTrack(643);
            Assert.That(track, Is.SameAs(expectedTrack));
        }





//                [Test]
//                public void SearchCreatesProperRequest()
//                {
//                    var expectedTracks = new List<Track>{new Track()};
//                   var request = new RestRequest();
//                   request.AddParameter("consumer_key", "apigee");
//                   //            request.AddParameter("filter", "all");
//                   //            request.AddParameter("limit", criteria.MaxResults);
//                   //            request.AddParameter("q", criteria.SearchText);
//                   _musicService.Setup(mock => mock.CallMusicService<List<Track>>(It.IsAny<RestRequest>())).Callback((RestRequest actual) => RequestsAreEqual(request, actual)).Returns(expectedTracks);
//                    var tracks = _trackApi.Search(new TrackCriteria());
//                    Assert.That(tracks, Is.SameAs(expectedTracks));
//                }
//
//                private void RequestsAreEqual(RestRequest expected, RestRequest actual)
//                {
//                    Assert.That(actual.Parameters, Is.EquivalentTo(expected.Parameters));
//                }

    }
}

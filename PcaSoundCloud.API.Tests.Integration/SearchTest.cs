using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PcaSoundCloud.Shared.Entities;
using RestSharp;

namespace PcaSoundCloud.API.Tests.Integration
{
    [TestFixture]
    public class SearchTest
    {
        private RestClient _client;

        // https://api.soundcloud.com/tracks.format?consumer_key=apigee&filter=all&order=created_at&limit=3&username=Vindata

        [SetUp]
        public void Setup()
        {
            _client = new RestClient("https://api.soundcloud.com/");
        }

        [Test]
        public void ConstructValidURL()
        {
            var request = new RestRequest("tracks.format", Method.GET);
            request.AddParameter("consumer_key", "apigee");
            request.AddParameter("filter", "all");
            request.AddParameter("limit", "1");

            var response = _client.Execute(request);

            Assert.That(response.ResponseUri.ToString(), Is.EqualTo(
                "https://api.soundcloud.com/tracks.format?consumer_key=apigee&filter=all&limit=1"));
        }

        [Test]
        public void CanSearch()
        {
            var request = new RestRequest("tracks.format", Method.GET);
            request.AddParameter("consumer_key", "apigee");
            request.AddParameter("filter", "all");
            request.AddParameter("limit", "1");

            var response = _client.Execute(request);

            var content = response.Content;
            Assert.That(content.Contains("404 - Not Found"), Is.EqualTo(false));
            Assert.That(content.Contains("401 - Unauthorized"), Is.EqualTo(false));
        }

        [Test]
        public void CanDeserialize()
        {
            var request = new RestRequest("tracks.format", Method.GET);
            request.AddParameter("consumer_key", "apigee");
            request.AddParameter("filter", "all");
            request.AddParameter("limit", "1");

            var response = _client.Execute<Track>(request);

            var data = response.Data;
            Assert.That(data.Id, Is.Not.Null);
        }

        [Test]
        public void CanDeserializeData()
        {
            var request = new RestRequest("tracks.format", Method.GET);
            request.AddParameter("consumer_key", "apigee");
            request.AddParameter("filter", "all");
            request.AddParameter("limit", "1");

            var response = _client.Execute<Track>(request);

            var data = response.Data;
            Assert.That(data.User.Kind, Is.EqualTo("user"));
            Assert.That(data.User.Permalink, Is.Not.Null);
            Assert.That(data.User.PermalinkUrl, Is.Not.Null);
            Assert.That(data.User.AvatarUrl, Is.Not.Null);
        }

        [Test]
        public void CanReceiveMultipleTracksBack()
        {
            var request = new RestRequest("tracks.format", Method.GET);
            request.AddParameter("consumer_key", "apigee");
            request.AddParameter("filter", "all");
            request.AddParameter("limit", "2");

            var response = _client.Execute<List<Track>>(request);

            var data = response.Data;
            Assert.That(data.Count, Is.EqualTo(2));
        }

        [Test]
        public void CanSearchForSongsByName()
        {
            var request = new RestRequest("tracks.format", Method.GET);
            request.AddParameter("consumer_key", "apigee");
            request.AddParameter("filter", "all");
            request.AddParameter("limit", "10");
            request.AddParameter("q", "04082012");

            var response = _client.Execute<List<Track>>(request);

            var data = response.Data;
            Assert.That(data.Any(x => x.Title.Contains("04082012")), Is.True);
        }
    }
}

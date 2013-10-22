using FluentAssertions;
using NUnit.Framework;
using PcaSoundCloud.Shared.Entities;
using RestSharp;

namespace PcaSoundCloud.API.Tests.Unit
{
    public class FakeMusicServiceTests
    {
        [Test]
        public void Return_data()
        {
            var service = new FakeMusicService();
            var data = service.CallMusicService<Track>(new RestRequest());
            data.Should().NotBe(null);
            data.GetType().Should().Be(typeof(Track));
        } 
    }
}
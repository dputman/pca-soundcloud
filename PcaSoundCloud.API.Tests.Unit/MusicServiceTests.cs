using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PcaSoundCloud.Shared.Entities;
using RestSharp;


namespace PcaSoundCloud.API.Tests.Unit
{
    [TestFixture()]
    public class MusicServiceTests
    {
        private MusicService _nSound;
        Mock<RestClient> _mock = new Mock<RestClient>();
        Mock<RestRequest> _moqRequest = new Mock<RestRequest>();

        [SetUp]
        public void Init()
        {
            _nSound = new MusicService(_mock.Object);
        }

        [Test]
        public void ApiDesign()
        {
            var service = new MusicService();
            service.SetApiKey("fake key");
            Track result = service.CallMusicService<Track>(new RestRequest());
        }

        //[Test]
        //public void Test_AddsApiKeyToRestRequest()
        //{
        //    _nSound.CallMusicService<object>(_moqRequest.Object);
        //    _mock.Verify(v => v.Execute(_moqRequest.Object));
        //   // _moqRequest.Verify(r => r.AddParameter("oath_token", NSoundCloud.TestToken));
        //}
    }
}

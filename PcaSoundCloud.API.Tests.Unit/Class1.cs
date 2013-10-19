using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using RestSharp;


namespace PcaSoundCloud.API.Tests.Unit
{
    [TestFixture()]
    public class Class1
    {
        private NSoundCloud _nSound;
        Mock<RestClient> _mock = new Mock<RestClient>();
        Mock<RestRequest> _moqRequest = new Mock<RestRequest>();

        [SetUp]
        public void Init()
        {
            _nSound = new NSoundCloud(_mock.Object);
        }

        [Test]
        public void Test_AddsApiKeyToRestRequest()
        {

            _nSound.CallMusicService<object>(_moqRequest.Object);
            _mock.Verify(v => v.Execute(_moqRequest.Object));
           // _moqRequest.Verify(r => r.AddParameter("oath_token", NSoundCloud.TestToken));
            
            

        }
    
    }
}

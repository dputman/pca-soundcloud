using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Should;

namespace PcaSoundCloud.API.Tests.Integration
{
    class UserApiTests
    {
        private const string TestToken = "1-55455-62452880-fe694f0d2b2f7fa";
        private UserApi _service;

        [SetUp]
        public void SetUp()
        {
            // arrange
            _service = new UserApi(new MusicService());
        }
        [Test]
        public void GetUserNameShouldReturnSomethingTest()
        {
            // act
            var me = _service.GetUserByAccessToken(TestToken);

            // assert
            me.ShouldNotBeNull();
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using FluentAssertions;
using NUnit.Framework;
using PcaSoundCloud.Shared;
using RestSharp;
using Moq;
using Should;

namespace PcaSoundCloud.API.Tests.Unit
{
    public class SoundCloudServiceTests
    {
        //Mock<RestClient> _mock = new Mock<RestClient>();
        //Mock<RestRequest> _moqRequest = new Mock<RestRequest>();

        private Mock<IMusicService> _mockMusicService;
        private SoundCloudService _service;

        [SetUp]
        public void SetUp()
        {
            _mockMusicService = new Mock<IMusicService>();
            _service = new SoundCloudService(_mockMusicService.Object);
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void IfUserDoesntExistExpectAnException()
        {
            _mockMusicService.Setup(sut => sut.CallMusicService<User>(It.IsAny<RestRequest>())).Returns((User)null);

            User user = _service.GetUserByID(-1);
        }

        [Test]
        public void GetUserShouldBeOfTypeUser()
        {
            _mockMusicService.Setup(sut => sut.CallMusicService<User>(It.IsAny<RestRequest>())).Returns(new User());

            User user = _service.GetUserByID(111);
            Assert.That(user, Is.TypeOf<User>());
        }

        //[Test]
        //public void GetUserByIdShouldReturnTheSelectedUser()
        //{
        //    User user = new User();
        //    user.id = 123;

        //    _mockMusicService.Setup(sut => sut.CallMusicService<User>(It.IsAny<RestRequest>())).Returns((User)user);

        //    Assert.That(user.id, Is.EqualTo(123));
        //}

        //[Test]
        //public void GetListOfUsersShouldReturListOfUsers()
        //{
        //    _mockMusicService.Setup(sut => sut.CallMusicService<List<User>>(It.IsAny<RestRequest>())).Returns(new List<User>());

        //    List<User> user = service.GetListOfUsers("Jimmy");
        //    Assert.That(user, Is.TypeOf<List<User>>());
        //}
    }
}
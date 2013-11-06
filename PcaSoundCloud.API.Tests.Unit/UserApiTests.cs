using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Reflection;
using FluentAssertions;
using NUnit.Framework;
using PcaSoundCloud.Shared;
using RestSharp;
using Moq;
using Should;

namespace PcaSoundCloud.API.Tests.Unit
{
    public class UserApiTests
    {
        private Mock<IMusicService> _mockMusicService;
        private UserApi _service;

        [SetUp]
        public void SetUp()
        {
            _mockMusicService = new Mock<IMusicService>();
            _service = new UserApi(_mockMusicService.Object);
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void IfUserDoesntExistExpectAnException()
        {
            _mockMusicService.Setup(sut => sut.CallMusicService<User>(It.IsAny<RestRequest>())).Returns((User)null);

            User user = _service.GetUserById(-1);
        }

        [Test]
        public void GetUserShouldBeOfTypeUser()
        {
            _mockMusicService.Setup(sut => sut.CallMusicService<User>(It.IsAny<RestRequest>())).Returns(new User());

            User user = _service.GetUserById(111);
            Assert.That(user, Is.TypeOf<User>());
        }

        [Test]
        public void GetListOfUsersShouldReturnListOfUsers()
        {
            _mockMusicService.Setup(sut => sut.CallMusicService<List<User>>(It.IsAny<RestRequest>())).Returns(new List<User>());

            var user = _service.GetListOfUsers("futurefocus");
            Assert.That(user, Is.TypeOf<List<User>>());
        }

        [Test]
        public void GetListOfUsersYouAreFollowing()
        {
            var users = _service.GetListOfFollowedUsers(62262046);

            Assert.That(users, Is.TypeOf<List<User>>());
        }

        [Test]
        public void GetListOfUsersIAmFollowing()
        {
            var users = _service.GetListOfMyFollowedUsers();

            Assert.That(users, Is.TypeOf<List<User>>());
        }

        [Test]
        public void FollowAGivenUser()
        {
            var user = _service.FollowUser(123);
            Assert.That(user, Is.TypeOf<User>());
        }
    }
}
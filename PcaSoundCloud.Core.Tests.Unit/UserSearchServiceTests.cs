using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PcaSoundCloud.API;
using PcaSoundCloud.Core.Interfaces;
using PcaSoundCloud.Shared;

namespace PcaSoundCloud.Core.Tests.Unit
{
    internal class UserSearchServiceTests
    {
        private Mock<IUserApi> _mockUserApi;
        private UserSearchService _service;

        [SetUp]
        public void SetUp()
        {
            _mockUserApi = new Mock<IUserApi>();
            _service = new UserSearchService(_mockUserApi.Object);
        }

        [Test]
        public void IsAnIUserSearchService()
        {
            Assert.That(_service, Is.InstanceOf<IUserSearchService>());
        }

        [Test]
        public void WhenWeCallGetListOfUsersReturnsListOfUsersWhenRequested()
        {
            var searchQuery = "Obvious Test User!";
            var mockUsers = new List<User>();
            
            _mockUserApi.Setup(sut => sut.GetListOfUsers(searchQuery)).Returns(mockUsers).Verifiable();
            var users = _service.GetListOfUsers(searchQuery);
            Assert.That(users, Is.SameAs(mockUsers));
           
            _mockUserApi.Verify();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using PcaSoundCloud.Core;
using PcaSoundCloud.Shared;
using PcaSoundCloud.Web.Controllers;

namespace PcaSoundCloud.Web.Tests.Unit
{
    public class UserSearchControllerTests
    {

        private Mock<IUserSearchService> _mockUserSearchService;
        private UserSearchController _controller;

        [SetUp]
        public void SetUp()
        {
            _mockUserSearchService = new Mock<IUserSearchService>();
            _controller = new UserSearchController(_mockUserSearchService.Object);
        }

        [Test]
        public void WhenWeCallGetListOfUsersReturnsListOfUsersThatWeRequested()
        {
            var searchQuery = "Obvious Test User!";
            var mockUsers = new List<User>();


            _mockUserSearchService.Setup(sut => sut.GetListOfUsers(searchQuery)).Returns(mockUsers);

            var view = _controller.Index(searchQuery) as ViewResult;
            Assert.That(view.Model, Is.SameAs(mockUsers));
        }
    }
}

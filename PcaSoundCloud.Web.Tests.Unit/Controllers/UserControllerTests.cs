using System.Collections.Generic;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using PcaSoundCloud.Core;
using PcaSoundCloud.Shared;
using PcaSoundCloud.Shared.Entities;
using PcaSoundCloud.Web.Controllers;
using PcaSoundCloud.Core.Interfaces;

namespace PcaSoundCloud.Web.Tests.Unit.Controllers
{
    class UserControllerTests
    {
        [Test]
        public void index_returns_userindexviewmodel()
        {
            Mock<IUserService> userService = new Mock<IUserService>();
            var controller = new UserController(userService.Object);

            var actual = controller.Index(0) as ViewResult;

            Assert.That(actual.Model, Is.TypeOf<UserIndexViewModel>());
        }



    }
}

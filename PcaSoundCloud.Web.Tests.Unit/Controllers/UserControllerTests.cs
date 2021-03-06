﻿using System.Collections.Generic;
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
        public void index_returns_userindexviewmodel(ITrackService trackService)
        {
            Mock<IUserService> userService = new Mock<IUserService>();
            var controller = new UserController(userService.Object, trackService);

            var actual = controller.Index(0) as ViewResult;

            Assert.That(actual.Model, Is.TypeOf<UserIndexViewModel>());
        }

        [Test]
        public void index_populates_user_object_in_view_model(ITrackService trackService)
        {
            var testId = 1;
            Mock<IUserService> userService = new Mock<IUserService>();
            userService.Setup(x => x.GetUserById(testId)).Returns(new User { id = testId });
            var controller = new UserController(userService.Object, trackService);

            var actual = controller.Index(testId) as ViewResult;

            var model = actual.Model as UserIndexViewModel;

            Assert.That(model.User, Is.Not.Null);


        }

        [Test]
        public void index_populates_fav_list_in_view_model()
        {
            const int testId = 1;
            var userService = new Mock<IUserService>();
            var trackService = new Mock<ITrackService>();
            trackService.Setup(x => x.GetFavoriteTracksByUserId(testId)).Returns(new List<Track>()
            {
                new Track()
                {
                    Description = "track1"
                }
            });
            var controller = new UserController(userService.Object, trackService.Object);

            var actual = controller.Index(testId) as ViewResult;

            var model = actual.Model as UserIndexViewModel;

            Assert.That(model.Favorites, Is.Not.Empty);

        }





    }
}

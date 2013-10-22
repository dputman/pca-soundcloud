using Castle.Windsor;
using NUnit.Framework;
using PcaSoundCloud.Web.Controllers;
using PcaSoundCloud.Web.Injection;

namespace PcaSoundCloud.Web.Tests.Functional.Controllers
{
    [TestFixture]
    public class SearchControllerTests
    {
        [Test] // will fail
        public void CanResolve()
        {
            var container = new WindsorContainer()
                .Install(new ControllerInstaller())
                .Install(new ServiceInstaller());

            var controller = container.Resolve<SearchController>();
            Assert.That(controller, Is.Not.Null);
        }
    }
}

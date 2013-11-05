using System.Web.Mvc;
using Castle.Windsor;
using log4net.Config;
using PcaSoundCloud.API.Injection;
using PcaSoundCloud.Core;
using PcaSoundCloud.Core.Injection;
using PcaSoundCloud.Web.Injection;

namespace PcaSoundCloud.Web
{
    public class WebBootstrapper
    {
        public void Run()
        {
            XmlConfigurator.Configure();

            var windsor = new WindsorContainer()
                .Install(new ApiInstaller())
                .Install(new ControllerInstaller())
                .Install(new ServiceInstaller());
            var controllerFactory = new ControllerFactory(windsor.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }
    }
}
using System.Web.Mvc;
using Castle.Windsor;
using log4net.Config;
using PcaSoundCloud.Core;
using PcaSoundCloud.Web.Injection;

namespace PcaSoundCloud.Web
{
    public class WebBootstrapper
    {
        public void Run()
        {
            XmlConfigurator.Configure();

            var windsor = new WindsorContainer()
                //.Install(new WebRepositoryInstaller())
                .Install(new ControllerInstaller())
                .Install(new ServiceInstaller());
                //.Install(new ApplicationConfigurationInstaller())
            var controllerFactory = new ControllerFactory(windsor.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }
    }
}
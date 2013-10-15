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

            IocContainer.Windsor = new WindsorContainer()
              //  .Install(new WebRepositoryInstaller())
                .Install(new ControllerInstaller());
                //.Install(new ApplicationConfigurationInstaller())
            var controllerFactory = new ControllerFactory(IocContainer.Windsor.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }
    }
}
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using PcaSoundCloud.Core;
using PcaSoundCloud.Shared;

namespace PcaSoundCloud.Web.Injection
{
    public class ApiInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IUser>()
                .ImplementedBy<TrackService>().LifestylePerWebRequest());
            container.Register(Component.For<IUserSearchService>()
               .ImplementedBy<UserSearchService>().LifestylePerWebRequest());
        }
    }
}git 
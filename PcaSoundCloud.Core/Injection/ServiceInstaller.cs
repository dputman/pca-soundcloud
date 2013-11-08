using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using PcaSoundCloud.Core.Interfaces;
using PcaSoundCloud.Shared;

namespace PcaSoundCloud.Core.Injection
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<ITrackService>()
                .ImplementedBy<TrackService>().LifestylePerWebRequest());
						container.Register(Component.For<IUserSearchService>()
							 .ImplementedBy<UserSearchService>().LifestylePerWebRequest());
						container.Register(Component.For<IUserService>()
								.ImplementedBy<UserService>().LifestylePerWebRequest());
				}
    }
}
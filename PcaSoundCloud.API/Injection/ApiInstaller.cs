using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using PcaSoundCloud.Shared;

namespace PcaSoundCloud.API.Injection
{
    public class ApiInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IMusicService>()
                .ImplementedBy<MusicService>().LifestylePerWebRequest());
            container.Register(Component.For<IUserApi>()
                .ImplementedBy<UserApi>().LifestylePerWebRequest());
            container.Register(Component.For<ITrackApi>()
                .ImplementedBy<TrackApi>().LifestylePerWebRequest());
        }
    }
}
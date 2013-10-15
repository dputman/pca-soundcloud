using System;
using System.Web.Mvc;
using Castle.MicroKernel;

namespace PcaSoundCloud.Web.Injection
{
    public class ControllerResolver : IHandlersFilter
    {
        public bool HasOpinionAbout(Type service)
        {
            return service == typeof(IController);
        }

        public IHandler[] SelectHandlers(Type service, IHandler[] handlers)
        {
            return handlers;
        }
    }
}
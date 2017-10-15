using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using Castle.Windsor;

namespace JustEat.TechTest.WebApi.IoC
{
    /// <summary>
    ///     http://blog.devdave.com/2015/05/setting-up-web-api-2-with-windsor-using.html
    /// </summary>
    internal sealed class CastleWindsorHttpDependencyResolver : IDependencyResolver
    {
        private readonly IWindsorContainer _container;

        public CastleWindsorHttpDependencyResolver(IWindsorContainer container)
        {
            _container = container;
        }

        public object GetService(Type t)
        {
            return _container.Kernel.HasComponent(t)
                ? _container.Resolve(t) : null;
        }

        public IEnumerable<object> GetServices(Type t)
        {
            return _container.ResolveAll(t)
                .Cast<object>().ToArray();
        }

        public IDependencyScope BeginScope()
        {
            return new CastleWindsorDependencyScope(_container);
        }

        public void Dispose()
        {
        }
    }
}
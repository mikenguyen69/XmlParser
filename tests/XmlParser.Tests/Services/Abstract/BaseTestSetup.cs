using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using XmlParser.Entities;
using XmlParser.Interfaces;
using XmlParser.Services;

namespace XmlParser.Tests.Services.Abstract
{
    public abstract class BaseTestSetup
    {
        protected IParser<EventInput> _parser;
        private static IServiceProvider _serviceProvider;
        public BaseTestSetup()
        {
            RegisterServices();
            ResolveService();
        }

        private void RegisterServices()
        {
            var builder = new ContainerBuilder();
            
            // register for services
            builder.RegisterType<StandardXmlParser<EventInput>>().As<IParser<EventInput>>();

            var appContainer = builder.Build();
            _serviceProvider = new AutofacServiceProvider(appContainer);
        }

        private void ResolveService()
        {
            _parser = _serviceProvider.GetService<IParser<EventInput>>();
        }
    }
}
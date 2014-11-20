using System;
using System.Reflection;
using System.Security.Policy;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using AcklenAvenue.Data.NHibernate;
using AutoMapper;
using BootstrapMvcSample;
using BootstrapSupport;
using Data;
using Domain.Services;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Context;
using Ninject;
using Ninject.Web.Common;

namespace MiPrimerMVC
{
    public class MvcApplication : NinjectHttpApplication
    {
        public static ISessionFactory SessionFactory = CreateSessionFactory();

        public MvcApplication()
        {
            BeginRequest += MvcApplication_BeginRequest;
            EndRequest += MvcApplication_EndRequest;
        }

        private void MvcApplication_EndRequest(object sender, EventArgs e)
        {
            CurrentSessionContext.Unbind(SessionFactory).Dispose();
        }

        private void MvcApplication_BeginRequest(object sender, EventArgs e)
        {
            CurrentSessionContext.Bind(SessionFactory.OpenSession());
        }

        public static ISessionFactory CreateSessionFactory()
        {
            string connectionString = ConnectionStrings.Get();
            MsSqlConfiguration databaseConfiguration = MsSqlConfiguration.MsSql2008.ShowSql().
                ConnectionString(x => x.Is(connectionString));
            ISessionFactory sessionFactory =
                new SessionFactoryBuilder(new MappingScheme(), databaseConfiguration).Build();
            return sessionFactory;
        }

        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BootstrapBundleConfig.RegisterBundles(BundleTable.Bundles);
            ExampleLayoutsRouteConfig.RegisterRoutes(RouteTable.Routes);
            AutoMapperConfig.RegisterMaps();
            //BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            kernel.Bind<IReadOnlyRepository>().To<ReadOnlyRepository>();
            kernel.Bind<IWriteOnlyRepository>().To<WriteOnlyRepository>();
            kernel.Bind<IPasswordEncryptor>().To<HashPasswordEncryptor>();
            kernel.Bind<ISession>().ToMethod(x => SessionFactory.GetCurrentSession());
            kernel.Bind<IMappingEngine>().ToConstant(Mapper.Engine);
            return kernel;
        }

    }
}
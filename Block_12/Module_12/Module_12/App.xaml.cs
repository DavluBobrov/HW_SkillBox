using Autofac;
using Autofac.Features.ResolveAnything;
using Module_12.Models.Repositories;
using Module_12.Models.Services;
using System.Windows;

namespace Module_12
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IContainer Container { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var builder = new ContainerBuilder();
            builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());
            builder.RegisterType<ClientsRepo>().As<IClientsRepo>().SingleInstance();
            builder.RegisterType<EmployeesRepo>().As<IEmployeesRepo>().SingleInstance();
            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>().SingleInstance();
            builder.RegisterType<ClientService>().As<IClientService>().SingleInstance();
            Container = builder.Build();
        }
    }
}
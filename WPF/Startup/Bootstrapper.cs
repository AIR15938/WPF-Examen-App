using Autofac;
using Prism.Events;
using WPF.DataAccess;
using WPF.Repositories;
using WPF.Services;
using WPF.ViewModel;

namespace WPF.Startup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();

            builder.RegisterType<AppDbContext>().AsSelf();

            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();

            builder.RegisterType<MessageDialog>().As<IMessageDialog>();

            builder.RegisterType<NavigationViewModel>().As<INavigationViewModel>();
            builder.RegisterType<NavigationRepository>().AsImplementedInterfaces();

            builder.RegisterType<EntityDetailViewModel>().As<IEntityDetailViewModel>();           
            builder.RegisterType<EntityRepository>().As<IEntityRepository>();

            return builder.Build();
        }
    }
}

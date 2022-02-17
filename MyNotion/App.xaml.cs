using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Autofac;
using MyNotion.Model.Abstract;
using MyNotion.Model.EntityFramework;
using MyNotion.ViewModel;

namespace MyNotion
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<EFRepository>().As<IRepository>();
            builder.RegisterType<MyNotionDbContext>().AsSelf();
            builder.RegisterType<MainWindowViewModel>().AsSelf();
            builder.RegisterType<AddWindowViewModel>().AsSelf();
            var container = builder.Build();
            var mainWindowViewModel = container.Resolve<MainWindowViewModel>();

            var mainWindow = new MainWindow { DataContext = mainWindowViewModel };
            mainWindow.Show();
        }
    }
}

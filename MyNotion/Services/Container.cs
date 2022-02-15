using Autofac;
using System;
using System.Windows.Input;
using WPF_MVVM_Classes;

namespace MyNotion.Services
{
    public class Container
    {
        
        public static ContainerBuilder ContainerMain()
        {
            var builder = new ContainerBuilder();
            builder.Register((c,p) => new RelayCommand(p.Named<Action<object>>("p1"))).AsSelf().As<ICommand>();
            return builder;
        }
    }
}

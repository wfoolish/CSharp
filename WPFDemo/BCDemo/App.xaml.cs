using BCDemo.Base;
using BCDemo.IViewModels;
using BCDemo.IViews;
using BCDemo.ViewModels;
using BCDemo.ViewModels.Chapter1;
using BCDemo.Views;
using BCDemo.Views.Chapter1;
using Prism.Ioc;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Unity;

namespace BCDemo
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            var win = Container.Resolve<IMainWindowViewModel>();
            return (Window)((ViewModelBase<IMainWindowView>)win).View;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IUnityContainer,UnityContainer>();

            containerRegistry.Register<IMainWindowView, MainWindowView>();
            containerRegistry.Register<IMainWindowViewModel, MainWindowViewModel>();

            containerRegistry.Register<IContentOne, ContentOne>();
            containerRegistry.Register<IContentOneViewModel, ContentOneViewModel>();

            containerRegistry.Register<IByteUpDownView, ByteUpDownView>();
            containerRegistry.Register<IByteUpDownViewModel, ByteUpDownViewModel>();
        }
    }
}

using BCDemo.IViewModels;
using BCDemo.IViews;
using BCDemo.ViewModels.Chapter1;
using BCDemo.Views;
using BCDemo.Views.Chapter1;
using Prism.Ioc;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BCDemo
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            var win = Container.Resolve<MainWindow>();
            return win;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IContentOne, ContentOne>();
            containerRegistry.Register<IContentOneViewModel, ContentOneViewModel>();
        }
    }
}

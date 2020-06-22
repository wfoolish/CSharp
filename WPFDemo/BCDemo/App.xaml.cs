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
using System.Reflection;
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
            containerRegistry.RegisterSingleton<IUnityContainer, UnityContainer>();

            //改成自动注册(利用export属性)
            //containerRegistry.Register<IMainWindowView, MainWindowView>();
            //containerRegistry.Register<IMainWindowViewModel, MainWindowViewModel>();

            //containerRegistry.Register<IByteUpDownView, ByteUpDownView>();
            //containerRegistry.Register<IByteUpDownViewModel, ByteUpDownViewModel>();

            InjectAuto(containerRegistry);
        }


        /// <summary>
        /// 自动扫描注册
        /// </summary>
        /// <param name="containerRegistry"></param>
        void InjectAuto(IContainerRegistry containerRegistry)
        {
            Assembly assembly = Assembly.GetCallingAssembly();
            Type[] current = assembly.GetExportedTypes();
            foreach (var name in current)
            {
                System.ComponentModel.Composition.ExportAttribute attr = (System.ComponentModel.Composition.ExportAttribute)name.GetCustomAttribute(typeof(System.ComponentModel.Composition.ExportAttribute), false);
                if (attr != null && attr.ContractType != null)
                {
                    containerRegistry.Register(attr.ContractType, name);
                }
            }
            AssemblyName[] names = assembly.GetReferencedAssemblies();
            foreach (var name in names)
            {
                Assembly assembly1 = Assembly.Load(name);
                Type[] types = assembly1.GetExportedTypes();
                foreach (var type in types)
                {
                    System.ComponentModel.Composition.ExportAttribute attr = (System.ComponentModel.Composition.ExportAttribute)type.GetCustomAttribute(typeof(System.ComponentModel.Composition.ExportAttribute), false);
                    if (attr != null && attr.ContractType != null)
                    {
                        containerRegistry.Register(attr.ContractType, type);
                    }
                }
            }
        }
    }
}

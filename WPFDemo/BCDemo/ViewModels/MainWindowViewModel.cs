using BCDemo.Base;
using BCDemo.IViewModels;
using BCDemo.IViews;
using BCDemo.ViewModels.Chapter1;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Unity;

namespace BCDemo.ViewModels
{
    [Export(typeof(IMainWindowViewModel))]
    public class MainWindowViewModel : ViewModelBase<IMainWindowView>, IMainWindowViewModel
    {
        public string Name { get; set; }

        public MainWindowViewModel(IByteUpDownViewModel byteUpDownViewModel, IMainWindowView view,
            IMultiLineTextEditorViewModel multiLineTextEditorViewMoel,
            IWindowContainerViewModel windowContainerViewModel) : base(view)
        {
            ByteUpDownCommand = new ActionCommand((obj) => { return true; }, null,
                (obj) =>
                {
                    ContentView = ((ViewModelBase<IByteUpDownView>)byteUpDownViewModel).View;
                });

            MultiLineTextEditorCommand = new ActionCommand((obj) => { return true; }, null,
                (obj) =>
                {
                    ContentView = ((ViewModelBase<IMultiLineTextEditorView>)multiLineTextEditorViewMoel).View;
                });
            WindowContainerCommand = new ActionCommand((obj) => { return true; }, null,
                (obj) =>
                {
                    ContentView = ((ViewModelBase<IWindowContainerView>)windowContainerViewModel).View;
                });
            DataGridCommand1 = new ActionCommand((obj) => { return true; }, null,
                (obj) =>
                {
                    ContentView = ((ViewModelBase<IWindowContainerView>)windowContainerViewModel).View;
                });
        }

        public IView ContentView
        {
            get { return _contentView; }
            set
            {
                _contentView = value;
                OnPropertyChanged(new PropertyChangedEventArgs("ContentView"));
            }
        }

        #region 页面功能菜单的Command
        public ActionCommand ByteUpDownCommand { get; set; }
        public ActionCommand MultiLineTextEditorCommand { get; set; }
        public ActionCommand WindowContainerCommand { get; set; }

        public ActionCommand DataGridCommand1 { get; set; }
        #endregion

        #region var
        private IView _contentView;
        #endregion
    }
}

using BCDemo.Base;
using BCDemo.IViewModels;
using BCDemo.IViews;
using BCDemo.ViewModels.Chapter1;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Unity;

namespace BCDemo.ViewModels
{
    public class MainWindowViewModel : ViewModelBase<IMainWindowView>, IMainWindowViewModel
    {
        public string Name { get; set; }

        public MainWindowViewModel(IByteUpDownViewModel byteUpDownViewModel, IMainWindowView view) : base(view)
        {
            ByteUpDown = new ActionCommand((obj) => { return true; }, null,
                (obj) =>
                {
                    ContentView = ((ViewModelBase<IByteUpDownView>)byteUpDownViewModel).View;
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

        public ActionCommand ByteUpDown { get; set; }

        #region var
        private IView _contentView;
        #endregion
    }
}

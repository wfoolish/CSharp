using BCDemo.Base;
using BCDemo.IViewModels;
using BCDemo.IViews;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BCDemo.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public string Name { get; set; }

        public MainWindowViewModel(IContentOneViewModel contentOneViewModel)
        {
            this.Name = "dfadfd";
            ContentOne = contentOneViewModel.View;
            Btn_1_1_Cmd = new ActionCommand((obj) => { return true; }, null, (obj) => { MessageBox.Show("fadfad"); });
        }

        public IView ContentOne { get; set; }

        public ActionCommand Btn_1_1_Cmd { get; set; }
    }
}

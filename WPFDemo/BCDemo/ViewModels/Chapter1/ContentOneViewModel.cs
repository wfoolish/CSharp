using BCDemo.Base;
using BCDemo.IViewModels;
using BCDemo.IViews;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BCDemo.ViewModels.Chapter1
{
    public class ContentOneViewModel : ViewModelBase<IContentOne>, IContentOneViewModel
    {
        private IContentOne _view;
        public ContentOneViewModel(IContentOne view) : base(view)
        {
            this._view = view;
            this.Name = "this is content one ";
        }

        IContentOne IContentOneViewModel.View => this._view;

        public string Name
        {
            get; set;
        }
    }
}

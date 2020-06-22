using BCDemo.Base;
using BCDemo.IViewModels;
using BCDemo.IViews;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCDemo.ViewModels.Chapter1
{
    [Export(typeof(IWindowContainerViewModel))]
    public class WindowContainerViewModel : ViewModelBase<IWindowContainerView>, IWindowContainerViewModel
    {
        public WindowContainerViewModel(IWindowContainerView view) : base(view)
        {
        }
    }
}

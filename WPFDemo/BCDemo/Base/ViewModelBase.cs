using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCDemo.Base
{
    public abstract class ViewModelBase<T> : BindableBase where T : IView
    {
        private IView _view;
        public ViewModelBase(IView view)
        {
            _view = view;
            _view.DataContext = this;
        }
    }
}

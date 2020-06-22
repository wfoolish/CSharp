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
        public ViewModelBase(IView view)
        {
            View = view;
            View.DataContext = this;
        }

        public IView View { get; set; }

       
    }
}

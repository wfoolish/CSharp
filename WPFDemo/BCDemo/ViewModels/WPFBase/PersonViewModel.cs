using BCDemo.Base;
using BCDemo.IViewModels.WPFBase;
using BCDemo.IViews.WPFBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCDemo.ViewModels.WPFBase
{
    public class PersonViewModel : ViewModelBase<IPersonView>, IPersonViewModel
    {
        public PersonViewModel(IPersonView view) : base(view)
        {
        }
    }
}

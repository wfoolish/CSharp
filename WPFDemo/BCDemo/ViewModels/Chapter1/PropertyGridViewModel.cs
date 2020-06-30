using BCDemo.Base;
using BCDemo.Entity;
using BCDemo.IViewModels.Xceed;
using BCDemo.IViews.Xceed;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCDemo.ViewModels.Xceed
{
    [Export(typeof(IPropertyGridViewModel))]
    public class PropertyGridViewModel : ViewModelBase<IPropertyGridView>, IPropertyGridViewModel
    {
        public PropertyGridViewModel(IPropertyGridView view) : base(view)
        {
            P1 = new Person { Name = "zhangsan", Age = 22 };
        }

        public Person P1 { get; set; }
    }
}

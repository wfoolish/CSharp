using BCDemo.Base;
using BCDemo.IViewModels;
using BCDemo.IViews;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCDemo.ViewModels.DevExpress
{
    [Export(typeof(IDataGridViewModel))]
    public class DataGridViewModel : ViewModelBase<IDataGridView>, IDataGridViewModel
    {
        public DataGridViewModel(IDataGridView view) : base(view)
        {
        }
    }
}

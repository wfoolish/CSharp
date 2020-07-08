using BCDemo.Base;
using BCDemo.Entity;
using BCDemo.IViewModels;
using BCDemo.IViews;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCDemo.ViewModels.WPFBase
{
    [Export(typeof(IDataTriggerViewModel))]
    public class DataTriggerViewModel : ViewModelBase<IDataTriggerView>, IDataTriggerViewModel
    {
        public DataTriggerViewModel(IDataTriggerView view) : base(view)
        {
            this.PersonOne = new Person() { Age = 22, Name = "张三" };
            this.PersonTwo = new Person() { Age = 23, Name = "李四" };
        }

        public Person PersonOne { get; set; }
        public Person PersonTwo { get; set; }
    }
}

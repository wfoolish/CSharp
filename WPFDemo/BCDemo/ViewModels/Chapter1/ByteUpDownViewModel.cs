using BCDemo.Base;
using BCDemo.IViewModels;
using BCDemo.IViews;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Unity;

namespace BCDemo.ViewModels.Chapter1
{
    [Export(typeof(IByteUpDownViewModel))]
    public class ByteUpDownViewModel : ViewModelBase<IByteUpDownView>, IByteUpDownViewModel
    {
        public ByteUpDownViewModel(IByteUpDownView view) : base(view)
        {
        }


        private int _day = 0;
        public int Day
        {
            get { return _day; }
            set
            {
                if (value > 10)
                {
                    MessageBox.Show(value.ToString());
                    return;
                }
                _day = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Day"));
            }
        }
    }
}

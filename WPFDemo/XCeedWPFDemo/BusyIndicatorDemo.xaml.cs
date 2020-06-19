using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace XCeedWPFDemo
{
    /// <summary>
    /// BusyIndicatorDemo.xaml 的交互逻辑
    /// </summary>
    public partial class BusyIndicatorDemo : Window
    {
        public BusyIndicatorDemo()
        {
            InitializeComponent();
            this.Loaded += BusyIndicatorDemo_Loaded;
        }

        private void BusyIndicatorDemo_Loaded(object sender, RoutedEventArgs e)
        {
            busy.IsBusy = true;
            Task.Run(()=> {
                Thread.Sleep(3000);
                busy.Dispatcher.Invoke(() => {

                    busy.IsBusy = false;
                });
            });
            
           
            
        }
    }
}

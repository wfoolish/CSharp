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
using Xceed.Wpf.Toolkit;

namespace XCeedWPFDemo
{
    /// <summary>
    /// ChildWindowDemo.xaml 的交互逻辑
    /// </summary>
    public partial class ChildWindowDemo : Window
    {
        public ChildWindowDemo()
        {
            InitializeComponent();
            childWin.CloseButtonClicked += ChildWin_CloseButtonClicked;
            this.Loaded += ChildWindowDemo_Loaded;
        }

        private void ChildWin_CloseButtonClicked(object sender, RoutedEventArgs e)
        {
            ChildWindow cw = sender as ChildWindow;
            cw.Visibility = Visibility.Collapsed;
        }

        private void ChildWindowDemo_Loaded(object sender, RoutedEventArgs e)
        {
            Task.Run(()=> {
                Thread.Sleep(2000);
                childWin.Dispatcher.Invoke(()=> {
                    childWin.Visibility = Visibility.Visible;
                });
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            List<Person> pList = new List<Person>();
            pList.Add(new Person() { UserName="张三",UserAge="22", UserAddress="武汉" });
            pList.Add(new Person() { UserName="张三",UserAge="22", UserAddress="武汉" });
            pList.Add(new Person() { UserName="李四",UserAge="22", UserAddress= "武汉" });
            this.listView.ItemsSource = pList;
        }
    }

    public class Person
    { 
        public string UserName { get; set; }
        public string UserAge { get; set; }
        public string UserAddress { get; set; }
    }
}

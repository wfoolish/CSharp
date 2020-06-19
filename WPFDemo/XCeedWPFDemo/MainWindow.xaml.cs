using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace XCeedWPFDemo
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

            propertyGrid.SelectedObject = new Person() { Name = "张三", Address = "wuhan",
                Father = new Parent() { Name="ddd",Relation="父亲" },
                Mother = new Parent() { Name = "ddd", Relation = "母亲" }
            };
            propertyGrid1.SelectedObject = new Person() { Name = "张三", Address = "wuhan" };
        }
    }

    public class Person
    {
        [DisplayName("姓名")]
        public string Name { get; set; }
        public string Address { get; set; }

        [Browsable(true)]
        public List<string> Phones { get; set; }

        [Category("父母")]
        [DisplayName("父亲")]
        [ExpandableObject]
        public Parent Father { get; set; }

        [Category("父母")]
        [DisplayName("母亲")]
        [ExpandableObject]
        
        public Parent Mother { get; set; }
    }

    public class Parent
    { 
        [PropertyOrder(3)]
        public string Relation { get; set; }
        [PropertyOrder(1)]
        public string Name { get; set; }
    }
}

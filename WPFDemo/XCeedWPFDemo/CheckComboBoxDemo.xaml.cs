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
using System.Windows.Shapes;

namespace XCeedWPFDemo
{
    /// <summary>
    /// CheckComboBoxDemo.xaml 的交互逻辑
    /// </summary>
    public partial class CheckComboBoxDemo : Window
    {
        public CheckComboBoxDemo()
        {
            InitializeComponent();
            this.Loaded += CheckComboBoxDemo_Loaded;
        }

        private void CheckComboBoxDemo_Loaded(object sender, RoutedEventArgs e)
        {
            List<Person> pList = new List<Person>();
            pList.Add(new Person() { Name = "adfafa", Address = "111" });
            pList.Add(new Person() { Name = "adfafa", Address = "111" });
            pList.Add(new Person() { Name = "adfafa", Address = "111" });
            this._combo.ItemsSource = pList;
        }
    }


}

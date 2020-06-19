using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace ControlTemplateView
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();

            this.Loaded += MainWindow_Loaded;
            this.DataContext = this;
        }

        private List<Type> _controlList;
        public List<Type> ControlList
        {
            get
            {
                if (_controlList == null)
                    _controlList = new List<Type>();
                return _controlList;
            }
            set
            {
                _controlList = value;
                OnPropertyChanged("ControlList");
            }
        }

        private string _ControlTemplateStr = string.Empty;
        public string ControlTemplateStr
        {
            get
            {
                return _ControlTemplateStr;
            }
            set
            {
                _ControlTemplateStr = value;
                OnPropertyChanged("ControlTemplateStr");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            List<Type> list = new List<Type>();
            Assembly assembly = Assembly.GetEntryAssembly();
            AssemblyName[] assemblyNames = assembly.GetReferencedAssemblies();
            foreach (var name in assemblyNames)
            {
                Assembly assembly1 = Assembly.Load(name);
                Type[] types = assembly1.GetTypes();
                foreach (var t in types)
                {
                    if (t.IsSubclassOf(typeof(Control)) && !t.IsInterface && !t.IsAbstract)
                    {
                        list.Add(t);
                    }
                }
            }
            list = list.AsEnumerable().OrderBy(itm => itm.Name).ToList();
            this.ControlList = list;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView view = sender as ListView;
            Type t = (Type)view.SelectedItem;
            Control control = (Control)Activator.CreateInstance(t);
            control.Visibility = Visibility.Collapsed;
            this.grid.Children.Add(control);
            ControlTemplate template = control.Template;
            StringBuilder sb = new StringBuilder();
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            XmlWriter xmlWriter = XmlWriter.Create(sb, settings);
            XamlWriter.Save(template, xmlWriter);
            //MessageBox.Show(result);
            ControlTemplateStr = sb.ToString();
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

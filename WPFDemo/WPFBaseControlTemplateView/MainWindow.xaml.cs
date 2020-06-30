using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WPFBaseControlTemplateView
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            this.Loaded += MainWindow_Loaded;
            this.ControlList = new ObservableCollection<Type>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Assembly entryAssembly = Assembly.GetEntryAssembly();
            AssemblyName[] assemblyNames = entryAssembly.GetReferencedAssemblies();
            foreach (var name in assemblyNames)
            {
                Type[] types = Assembly.Load(name).GetTypes();
                foreach (var v in types)
                {
                    if (v.IsSubclassOf(typeof(Control)) && v.IsPublic && v != typeof(Window) && !v.IsAbstract)
                    {
                        this.ControlList.Add(v);
                    }
                }
            }

        }


        /// <summary>
        /// 空间列表
        /// </summary>
        public ObservableCollection<Type> ControlList { get; set; }


        private string _ControlTemplateStr = string.Empty;

        /// <summary>
        /// 控件基础模板字符串
        /// </summary>
        public string ControlTemplateStr
        {
            get
            {
                return _ControlTemplateStr;
            }
            set
            {
                _ControlTemplateStr = value; OnPropertyChanged("ControlTemplateStr");
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox listBox = sender as ListBox;
            Type type = (Type)listBox.SelectedItem;
            try
            {
                Control control = (Control)Activator.CreateInstance(type);
                this.stackPanel.Children.Add(control);
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                StringBuilder sb = new StringBuilder();
                XamlWriter.Save(control.Template, XmlWriter.Create(sb, settings));
                this.ControlTemplateStr = sb.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}

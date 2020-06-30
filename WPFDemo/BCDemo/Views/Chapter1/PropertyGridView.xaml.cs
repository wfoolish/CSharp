﻿using BCDemo.IViews.Xceed;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
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

namespace BCDemo.Views.Xceed
{
    [Export(typeof(IPropertyGridView))]
    /// <summary>
    /// PropertyGridView.xaml 的交互逻辑
    /// </summary>
    public partial class PropertyGridView : UserControl, IPropertyGridView
    {
        public PropertyGridView()
        {
            InitializeComponent();
        }
    }
}

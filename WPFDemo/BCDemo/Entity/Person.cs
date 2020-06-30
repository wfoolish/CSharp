using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;

namespace BCDemo.Entity
{


    public class Person
    {
        [Category("Info")]
        [Editor(typeof(TextBoxEditor), typeof(TextBoxEditor))]
        public string Name { get; set; }

        [Category("Info")]
        [Editor(typeof(IntegerUpDownEditor), typeof(IntegerUpDownEditor))]
        public int Age { get; set; }
    }
}

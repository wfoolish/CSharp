using BCDemo.Base;
using BCDemo.IViews;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCDemo.ViewModels.Chapter1
{
    [Export(typeof(IMultiLineTextEditorView))]
    public class MultiLineTextEditorViewModel : ViewModelBase<IMultiLineTextEditorView>
    {
        public MultiLineTextEditorViewModel(IMultiLineTextEditorView view) : base(view)
        {
        }
    }
}

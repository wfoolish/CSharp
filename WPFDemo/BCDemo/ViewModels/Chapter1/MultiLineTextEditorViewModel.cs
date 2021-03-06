﻿using BCDemo.Base;
using BCDemo.IViewModels;
using BCDemo.IViews;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCDemo.ViewModels.Chapter1
{
    [Export(typeof(IMultiLineTextEditorViewModel))]
    public class MultiLineTextEditorViewModel : ViewModelBase<IMultiLineTextEditorView>, IMultiLineTextEditorViewModel
    {
        public MultiLineTextEditorViewModel(IMultiLineTextEditorView view) : base(view)
        {
        }
    }
}

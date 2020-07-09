using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BCDemo.UserControls
{
    [TemplatePart(Name = "PART_Head", Type = typeof(ContentControl))]
    [TemplatePart(Name = "PART_Body", Type = typeof(ContentControl))]
    [TemplatePart(Name = "PART_Foot", Type = typeof(ContentControl))]
    public class TemplatePartControl : Control
    {
        public TemplatePartControl()
        {

        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            StackPanel head = GetTemplateChild("PART_Head") as StackPanel;
            StackPanel body = GetTemplateChild("PART_Body") as StackPanel;
            StackPanel foot = GetTemplateChild("PART_Foot") as StackPanel;
            TextBlock tb1 = new TextBlock() { Text = "Head" };
            TextBlock tb2 = new TextBlock() { Text = "Body" };
            TextBlock tb3 = new TextBlock() { Text = "Foot" };
            head.Children.Add(tb1);
            body.Children.Add(tb2);
            foot.Children.Add(tb3);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel.Composition;

namespace AlmacenSL
{
    [Export]
    public partial class Shell : UserControl
    {
        [Import("ShellViewModel")]
        public object ViewModel
        {
            get { return this.DataContext; }
            set
            {
                DataContext = value;
            }
        }
        
        public Shell()
        {
            InitializeComponent();
        }
    }
}

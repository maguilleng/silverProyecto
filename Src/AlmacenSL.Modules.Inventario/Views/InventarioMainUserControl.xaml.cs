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
using Microsoft.Practices.Prism.Regions;

namespace AlmacenSL.Modules.Inventario.Views
{
    [Export]
    public partial class InventarioMainUserControl : UserControl
    {
        [Import]
        public IRegionManager RegionManager { get; set; }

        [Import]
        public InventarioViewModel ViewModel
        {
            get
            {
                return this.DataContext as InventarioViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }
        
        public InventarioMainUserControl()
        {
            InitializeComponent();
        }
    }
}

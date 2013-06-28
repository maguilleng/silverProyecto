using System;
using System.Windows;
using System.Linq;
using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.ViewModel;
using System.Windows.Data;
using System.Collections.ObjectModel;
using System.Collections;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;


namespace AlmacenSL.Modules.Inventario
{
    [Export]
    public class InventarioViewModel
    {
        [Import]
        public IRegionManager RegionManager { get; set; }

        public InventarioViewModel()
        { 
        }
    }
}

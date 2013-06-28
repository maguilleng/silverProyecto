using System;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Regions;
using System.ComponentModel.Composition;
using AlmacenSL.Modules.Inventario.Views;


namespace AlmacenSL.Modules.Inventario
{
    [ModuleExport(typeof(InventarioModule), InitializationMode = InitializationMode.OnDemand)]
    public class InventarioModule : IModule
    {
        [Import]
        public IRegionManager RegionManager { get; set; }
        
        private readonly IRegionManager regionManager;

        [ImportingConstructor]
        public InventarioModule(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public void Initialize()
        {
            try
            {
                //regionManager.RegisterViewWithRegion("MainContentRegion", typeof(ITicketMain));
                //regionManager.RequestNavigate("MainContentRegion", typeof(ITicketMain));
                RegionManager.RegisterViewWithRegion("MainContentRegion", typeof(InventarioMainUserControl));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}

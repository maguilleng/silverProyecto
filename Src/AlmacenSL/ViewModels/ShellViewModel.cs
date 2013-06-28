using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Events;
using System.ComponentModel;
using Microsoft.Practices.Prism.Commands;
using System.ComponentModel.Composition;
using System.Windows.Input;

namespace AlmacenSL.ViewModels
{
    [Export("ShellViewModel")]
    public class ShellViewModel
    {
        [Import(AllowRecomposition = false)]
        public IModuleManager ModuleManager;

        public ICommand LoadModuleCommand { get; private set; }

        [ImportingConstructor]
        public ShellViewModel(IEventAggregator eventAggregator)
        {
            this.LoadModuleCommand = new DelegateCommand<object>(this.OnLoadModule);
        }

        private void OnLoadModule(object obj)
        {
            this.ModuleManager.LoadModule("InventarioModule");
        }

        public void OnImportsSatisfied()
        {
            this.ModuleManager.ModuleDownloadProgressChanged += new EventHandler<ModuleDownloadProgressChangedEventArgs>(ModuleManager_ModuleDownloadProgressChanged);
            this.ModuleManager.LoadModuleCompleted += new EventHandler<LoadModuleCompletedEventArgs>(ModuleManager_LoadModuleCompleted);
        }

        private void ModuleManager_LoadModuleCompleted(object sender, LoadModuleCompletedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                //this.EventAggregator.GetEvent<ErrorEvent>().Publish(ex);
            }
        }

        private void ModuleManager_ModuleDownloadProgressChanged(object sender, ModuleDownloadProgressChangedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                //this.EventAggregator.GetEvent<ErrorEvent>().Publish(ex);
            }
        }
    }
}

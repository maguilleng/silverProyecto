using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Events;
using System.ComponentModel;
using Microsoft.Practices.Prism.Commands;
using System.ComponentModel.Composition;
using System.Windows.Input;
using Microsoft.Practices.Prism.ViewModel;
using System.ServiceModel.DomainServices.Client.ApplicationServices;
using AlmacenSL.Web;
using System.Linq;
using Microsoft.Practices.Prism.Regions;
using AlmacenSL.Infrastructure;

namespace AlmacenSL.ViewModels
{
    [Export("ShellViewModel")]
    public class ShellViewModel : NotificationObject
    {
        #region Propiedades y Atributos
        [Import(AllowRecomposition = false)]
        public IModuleManager ModuleManager;

        [Import]
        public IRegionManager RegionManager { get; set; }

        public ICommand LoginUserCommand { get; private set; }
        public ICommand CloseSessionCommand { get; set; }

        [ImportingConstructor]
        public ShellViewModel(IEventAggregator eventAggregator)
        {
            this.LoginUserCommand = new DelegateCommand<object>(this.OnLoginUser);
            this.CloseSessionCommand = new DelegateCommand<object>(this.OnCloseSession);
        }

        string strUser;
        public string StrUser
        {
            get { return strUser; }
            set 
            { 
                strUser = value;
                RaisePropertyChanged("StrUser");
            }
        }

        string strPassword;
        public string StrPassword
        {
            get { return strPassword; }
            set 
            {
                strPassword = value;
                RaisePropertyChanged("StrPassword");
            }
        }

        UserAuth currentUser;
        public UserAuth CurrentUser
        {
            get { return currentUser; }
            set 
            { 
                currentUser = value;
                RaisePropertyChanged("CurrentUser");
            }
        }
        #endregion

        private void OnLoginUser(object obj)
        {
            LoginParameters lp = new LoginParameters(StrUser, StrPassword);
            WebContext.Current.Authentication.Login(lp, LoginOperationCompleted, null);
        }
        private void LoginOperationCompleted(LoginOperation lo)
        {
            if (!lo.HasError)
            {
                if (lo.LoginSuccess)
                {
                    if (WebContext.Current.User.IsAuthenticated)
                    {
                        StrUser = String.Empty;
                        StrPassword = String.Empty;
                        CurrentUser = WebContext.Current.User;
                        //MessageBox.Show(CurrentUser.Roles.First());
                    }
                    this.RegionManager.RequestNavigate("HeaderRegion", "HeaderUserControl");
                    this.ModuleManager.LoadModule("InventarioModule");
                    this.ModuleManager.LoadModuleCompleted += ModuleManager_LoadModuleCompleted;
                    this.RegionManager.RequestNavigate("MainContentRegion", "InventarioMainUserControl");
                    this.RegionManager.RequestNavigate("MainMenuRegion", "MainMenuUserControl");
                }
                else
                    if (!lo.LoginSuccess)
                    {
                        MessageBox.Show("Usuario o Contraseña Incorrectos.");
                    }
            }
            else
            {
                MessageBox.Show("Error de Autenticación.");
            }
        }

        private void OnCloseSession(object obj)
        {
            WebContext.Current.Authentication.Logout(LogoutOperationCompleted, null);
        }
        private void LogoutOperationCompleted(LogoutOperation lo)
        {
            if(!lo.HasError)
            {
                CurrentUser = null;
                var region = this.RegionManager.Regions["MainContentRegion"];
                //region.ClearActiveViews();
                RegionManager.RequestNavigate("MainContentRegion", "LoginUserControl");

                var headerRegion = this.RegionManager.Regions["HeaderRegion"];
                headerRegion.ClearActiveViews();

                var menuRegion = this.RegionManager.Regions["MainMenuRegion"];
                menuRegion.ClearActiveViews();
            }
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
                this.RegionManager.RequestNavigate("MainContentRegion", "InventarioMainUserControl");
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

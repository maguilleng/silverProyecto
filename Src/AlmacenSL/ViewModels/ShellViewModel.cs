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

namespace AlmacenSL.ViewModels
{
    [Export("ShellViewModel")]
    public class ShellViewModel : NotificationObject
    {
        [Import(AllowRecomposition = false)]
        public IModuleManager ModuleManager;

        public ICommand LoadModuleCommand { get; private set; }

        [ImportingConstructor]
        public ShellViewModel(IEventAggregator eventAggregator)
        {
            this.LoadModuleCommand = new DelegateCommand<object>(this.OnLoadModule);
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


        private void OnLoadModule(object obj)
        {
            LoginParameters lp = new LoginParameters(StrUser, StrPassword);
            WebContext.Current.Authentication.Login(lp, LoginOperationCompleted, null);  
        }

        

        private void LoginOperationCompleted(LoginOperation lo)
        {
            if (!lo.HasError)
            {
                if(lo.LoginSuccess)
                {
                    if(WebContext.Current.User.IsAuthenticated)
                    {
                        UserAuth LoguedUser = WebContext.Current.User;
                        UserAuth usuario= (UserAuth)LoguedUser;
                        MessageBox.Show(LoguedUser.Roles.First());
                    }
                    this.ModuleManager.LoadModule("InventarioModule");
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

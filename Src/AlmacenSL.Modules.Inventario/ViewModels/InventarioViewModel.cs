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
using AlmacenSL.Web;

namespace AlmacenSL.Modules.Inventario
{
    [Export]
    public class InventarioViewModel : NotificationObject
    {
        [Import]
        public IRegionManager RegionManager { get; set; }

        public AlmacenDomainContext context { get; set; }

        ObservableCollection<Empleado> users;
        public ObservableCollection<Empleado> Users
        {
            get { return users; }
            set
            {
                users = value;
                RaisePropertyChanged("Users");
            }
        }

        public InventarioViewModel()
        {
            context = new AlmacenDomainContext();
            getUsers();
        }

        public void getUsers()
        {
            context.Load(context.GetEmpleadosQuery(), (result) =>
                                                    {
                                                        Users = new ObservableCollection<Empleado>(result.Entities);
                                                    }, null);
        }
    }
}

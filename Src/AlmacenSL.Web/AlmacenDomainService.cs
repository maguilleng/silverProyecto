
namespace AlmacenSL.Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.ServiceModel.DomainServices.EntityFramework;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;


    // Implementa la lógica de la aplicación mediante el contexto dbAlmacenEntities.
    // TODO: agregue la lógica de su aplicación a estos métodos o en métodos adicionales.
    // TODO: aplique la autenticación (Windows/ASP.NET Forms) y quite las marcas de comentario de lo siguiente para deshabilitar el acceso anónimo
    // Considere además la posibilidad de agregar roles para restringir el acceso según necesidad.
    [RequiresAuthentication]
    [EnableClientAccess()]
    public class AlmacenDomainService : DbDomainService<dbAlmacenEntities>
    {

        // TODO:
        // Considere la posibilidad de restringir los resultados de su método de consulta. Si necesita entradas adicionales, puede
        // agregar parámetros a este método o crear métodos de consulta adicionales con distintos nombres.
        // Para admitir la paginación tendrá que agregar ordenación a la consulta 'Empleados'.
        public IQueryable<Empleado> GetEmpleados()
        {
            return this.DbContext.Empleados;
        }

        public void InsertEmpleado(Empleado empleado)
        {
            DbEntityEntry<Empleado> entityEntry = this.DbContext.Entry(empleado);
            if ((entityEntry.State != EntityState.Detached))
            {
                entityEntry.State = EntityState.Added;
            }
            else
            {
                this.DbContext.Empleados.Add(empleado);
            }
        }

        public void UpdateEmpleado(Empleado currentEmpleado)
        {
            this.DbContext.Empleados.AttachAsModified(currentEmpleado, this.ChangeSet.GetOriginal(currentEmpleado), this.DbContext);
        }

        public void DeleteEmpleado(Empleado empleado)
        {
            DbEntityEntry<Empleado> entityEntry = this.DbContext.Entry(empleado);
            if ((entityEntry.State != EntityState.Deleted))
            {
                entityEntry.State = EntityState.Deleted;
            }
            else
            {
                this.DbContext.Empleados.Attach(empleado);
                this.DbContext.Empleados.Remove(empleado);
            }
        }

        // TODO:
        // Considere la posibilidad de restringir los resultados de su método de consulta. Si necesita entradas adicionales, puede
        // agregar parámetros a este método o crear métodos de consulta adicionales con distintos nombres.
        // Para admitir la paginación tendrá que agregar ordenación a la consulta 'Profiles'.
        public IQueryable<Profiles> GetProfiles()
        {
            return this.DbContext.Profiles;
        }

        public void InsertProfiles(Profiles profiles)
        {
            DbEntityEntry<Profiles> entityEntry = this.DbContext.Entry(profiles);
            if ((entityEntry.State != EntityState.Detached))
            {
                entityEntry.State = EntityState.Added;
            }
            else
            {
                this.DbContext.Profiles.Add(profiles);
            }
        }

        public void UpdateProfiles(Profiles currentProfiles)
        {
            this.DbContext.Profiles.AttachAsModified(currentProfiles, this.ChangeSet.GetOriginal(currentProfiles), this.DbContext);
        }

        public void DeleteProfiles(Profiles profiles)
        {
            DbEntityEntry<Profiles> entityEntry = this.DbContext.Entry(profiles);
            if ((entityEntry.State != EntityState.Deleted))
            {
                entityEntry.State = EntityState.Deleted;
            }
            else
            {
                this.DbContext.Profiles.Attach(profiles);
                this.DbContext.Profiles.Remove(profiles);
            }
        }

        // TODO:
        // Considere la posibilidad de restringir los resultados de su método de consulta. Si necesita entradas adicionales, puede
        // agregar parámetros a este método o crear métodos de consulta adicionales con distintos nombres.
        // Para admitir la paginación tendrá que agregar ordenación a la consulta 'Roles'.
        public IQueryable<Roles> GetRoles()
        {
            return this.DbContext.Roles;
        }

        public void InsertRoles(Roles roles)
        {
            DbEntityEntry<Roles> entityEntry = this.DbContext.Entry(roles);
            if ((entityEntry.State != EntityState.Detached))
            {
                entityEntry.State = EntityState.Added;
            }
            else
            {
                this.DbContext.Roles.Add(roles);
            }
        }

        public void UpdateRoles(Roles currentRoles)
        {
            this.DbContext.Roles.AttachAsModified(currentRoles, this.ChangeSet.GetOriginal(currentRoles), this.DbContext);
        }

        public void DeleteRoles(Roles roles)
        {
            DbEntityEntry<Roles> entityEntry = this.DbContext.Entry(roles);
            if ((entityEntry.State != EntityState.Deleted))
            {
                entityEntry.State = EntityState.Deleted;
            }
            else
            {
                this.DbContext.Roles.Attach(roles);
                this.DbContext.Roles.Remove(roles);
            }
        }

        // TODO:
        // Considere la posibilidad de restringir los resultados de su método de consulta. Si necesita entradas adicionales, puede
        // agregar parámetros a este método o crear métodos de consulta adicionales con distintos nombres.
        // Para admitir la paginación tendrá que agregar ordenación a la consulta 'UserInfo'.
        public IQueryable<UserInfo> GetUserInfo()
        {
            return this.DbContext.UserInfo;
        }

        public void InsertUserInfo(UserInfo userInfo)
        {
            DbEntityEntry<UserInfo> entityEntry = this.DbContext.Entry(userInfo);
            if ((entityEntry.State != EntityState.Detached))
            {
                entityEntry.State = EntityState.Added;
            }
            else
            {
                this.DbContext.UserInfo.Add(userInfo);
            }
        }

        public void UpdateUserInfo(UserInfo currentUserInfo)
        {
            this.DbContext.UserInfo.AttachAsModified(currentUserInfo, this.ChangeSet.GetOriginal(currentUserInfo), this.DbContext);
        }

        public void DeleteUserInfo(UserInfo userInfo)
        {
            DbEntityEntry<UserInfo> entityEntry = this.DbContext.Entry(userInfo);
            if ((entityEntry.State != EntityState.Deleted))
            {
                entityEntry.State = EntityState.Deleted;
            }
            else
            {
                this.DbContext.UserInfo.Attach(userInfo);
                this.DbContext.UserInfo.Remove(userInfo);
            }
        }

        // TODO:
        // Considere la posibilidad de restringir los resultados de su método de consulta. Si necesita entradas adicionales, puede
        // agregar parámetros a este método o crear métodos de consulta adicionales con distintos nombres.
        // Para admitir la paginación tendrá que agregar ordenación a la consulta 'Users'.
        public IQueryable<Users> GetUsers()
        {
            return this.DbContext.Users;
        }

        public void InsertUsers(Users users)
        {
            DbEntityEntry<Users> entityEntry = this.DbContext.Entry(users);
            if ((entityEntry.State != EntityState.Detached))
            {
                entityEntry.State = EntityState.Added;
            }
            else
            {
                this.DbContext.Users.Add(users);
            }
        }

        public void UpdateUsers(Users currentUsers)
        {
            this.DbContext.Users.AttachAsModified(currentUsers, this.ChangeSet.GetOriginal(currentUsers), this.DbContext);
        }

        public void DeleteUsers(Users users)
        {
            DbEntityEntry<Users> entityEntry = this.DbContext.Entry(users);
            if ((entityEntry.State != EntityState.Deleted))
            {
                entityEntry.State = EntityState.Deleted;
            }
            else
            {
                this.DbContext.Users.Attach(users);
                this.DbContext.Users.Remove(users);
            }
        }
    }
}



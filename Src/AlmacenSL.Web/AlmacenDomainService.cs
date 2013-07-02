
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
    // [RequiresAuthentication]
    [EnableClientAccess()]
    public class AlmacenDomainService : DbDomainService<dbAlmacenEntities>
    {

        // TODO:
        // Considere la posibilidad de restringir los resultados de su método de consulta. Si necesita entradas adicionales, puede
        // agregar parámetros a este método o crear métodos de consulta adicionales con distintos nombres.
        // Para admitir la paginación tendrá que agregar ordenación a la consulta 'Users'.
        public IQueryable<User> GetUsers()
        {
            return this.DbContext.Users;
        }

        public void InsertUser(User user)
        {
            DbEntityEntry<User> entityEntry = this.DbContext.Entry(user);
            if ((entityEntry.State != EntityState.Detached))
            {
                entityEntry.State = EntityState.Added;
            }
            else
            {
                this.DbContext.Users.Add(user);
            }
        }

        public void UpdateUser(User currentUser)
        {
            this.DbContext.Users.AttachAsModified(currentUser, this.ChangeSet.GetOriginal(currentUser), this.DbContext);
        }

        public void DeleteUser(User user)
        {
            DbEntityEntry<User> entityEntry = this.DbContext.Entry(user);
            if ((entityEntry.State != EntityState.Deleted))
            {
                entityEntry.State = EntityState.Deleted;
            }
            else
            {
                this.DbContext.Users.Attach(user);
                this.DbContext.Users.Remove(user);
            }
        }
    }
}



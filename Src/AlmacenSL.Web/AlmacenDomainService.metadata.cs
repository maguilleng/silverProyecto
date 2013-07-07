
namespace AlmacenSL.Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;


    // El MetadataTypeAttribute identifica a EmpleadoMetadata como la clase
    // que contiene metadatos adicionales para la class Empleado.
    [MetadataTypeAttribute(typeof(Empleado.EmpleadoMetadata))]
    public partial class Empleado
    {

        // Esta clase permite adjuntar atributos personalizados a properties
        // de la clase Empleado.
        //
        // Por ejemplo, lo siguiente marca la propiedad Xyz como una
        // propiedad requerida y especifica el formato de los valores válidos:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class EmpleadoMetadata
        {

            // No se van a crear instancias de las clases de metadatos.
            private EmpleadoMetadata()
            {
            }

            public string ApPaterno { get; set; }

            public int EmpleadoId { get; set; }

            public string Nombre { get; set; }
        }
    }

    // El MetadataTypeAttribute identifica a ProfilesMetadata como la clase
    // que contiene metadatos adicionales para la class Profiles.
    [MetadataTypeAttribute(typeof(Profiles.ProfilesMetadata))]
    public partial class Profiles
    {

        // Esta clase permite adjuntar atributos personalizados a properties
        // de la clase Profiles.
        //
        // Por ejemplo, lo siguiente marca la propiedad Xyz como una
        // propiedad requerida y especifica el formato de los valores válidos:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class ProfilesMetadata
        {

            // No se van a crear instancias de las clases de metadatos.
            private ProfilesMetadata()
            {
            }

            public DateTime LastUpdatedDate { get; set; }

            public string PropertyNames { get; set; }

            public byte[] PropertyValueBinary { get; set; }

            public string PropertyValueStrings { get; set; }

            public Guid UserId { get; set; }

            public Users Users { get; set; }
        }
    }

    // El MetadataTypeAttribute identifica a RolesMetadata como la clase
    // que contiene metadatos adicionales para la class Roles.
    [MetadataTypeAttribute(typeof(Roles.RolesMetadata))]
    public partial class Roles
    {

        // Esta clase permite adjuntar atributos personalizados a properties
        // de la clase Roles.
        //
        // Por ejemplo, lo siguiente marca la propiedad Xyz como una
        // propiedad requerida y especifica el formato de los valores válidos:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class RolesMetadata
        {

            // No se van a crear instancias de las clases de metadatos.
            private RolesMetadata()
            {
            }

            public Guid ApplicationId { get; set; }

            public Applications Applications { get; set; }

            public string Description { get; set; }

            public Guid RoleId { get; set; }

            public string RoleName { get; set; }

            public ICollection<Users> Users { get; set; }
        }
    }

    // El MetadataTypeAttribute identifica a UserInfoMetadata como la clase
    // que contiene metadatos adicionales para la class UserInfo.
    [MetadataTypeAttribute(typeof(UserInfo.UserInfoMetadata))]
    public partial class UserInfo
    {

        // Esta clase permite adjuntar atributos personalizados a properties
        // de la clase UserInfo.
        //
        // Por ejemplo, lo siguiente marca la propiedad Xyz como una
        // propiedad requerida y especifica el formato de los valores válidos:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class UserInfoMetadata
        {

            // No se van a crear instancias de las clases de metadatos.
            private UserInfoMetadata()
            {
            }

            public string ApMaterno { get; set; }

            public string ApPaterno { get; set; }

            public Nullable<int> Ficha { get; set; }

            public string Nombre { get; set; }

            public Guid UserId { get; set; }

            public Users Users { get; set; }
        }
    }

    // El MetadataTypeAttribute identifica a UsersMetadata como la clase
    // que contiene metadatos adicionales para la class Users.
    [MetadataTypeAttribute(typeof(Users.UsersMetadata))]
    public partial class Users
    {

        // Esta clase permite adjuntar atributos personalizados a properties
        // de la clase Users.
        //
        // Por ejemplo, lo siguiente marca la propiedad Xyz como una
        // propiedad requerida y especifica el formato de los valores válidos:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class UsersMetadata
        {

            // No se van a crear instancias de las clases de metadatos.
            private UsersMetadata()
            {
            }

            public Guid ApplicationId { get; set; }

            public Applications Applications { get; set; }

            public bool IsAnonymous { get; set; }

            public DateTime LastActivityDate { get; set; }

            public Memberships Memberships { get; set; }

            public Profiles Profiles { get; set; }

            public ICollection<Roles> Roles { get; set; }

            public Guid UserId { get; set; }

            public UserInfo UserInfo { get; set; }

            public string UserName { get; set; }
        }
    }
}

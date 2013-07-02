
namespace AlmacenSL.Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;


    // El MetadataTypeAttribute identifica a UserMetadata como la clase
    // que contiene metadatos adicionales para la class User.
    [MetadataTypeAttribute(typeof(User.UserMetadata))]
    public partial class User
    {

        // Esta clase permite adjuntar atributos personalizados a properties
        // de la clase User.
        //
        // Por ejemplo, lo siguiente marca la propiedad Xyz como una
        // propiedad requerida y especifica el formato de los valores válidos:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class UserMetadata
        {

            // No se van a crear instancias de las clases de metadatos.
            private UserMetadata()
            {
            }

            public string contrasena { get; set; }

            public Nullable<int> creationDate { get; set; }

            public string nombre { get; set; }

            public Nullable<int> status { get; set; }

            public int userId { get; set; }

            public string usuario { get; set; }
        }
    }
}

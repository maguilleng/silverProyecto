﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AlmacenSL.Web
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class dbAlmacenEntities : DbContext
    {
        public dbAlmacenEntities()
            : base("name=dbAlmacenEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Applications> Applications { get; set; }
        public DbSet<Memberships> Memberships { get; set; }
        public DbSet<Profiles> Profiles { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}

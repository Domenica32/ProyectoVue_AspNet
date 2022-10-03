using System;
using System.Collections.Generic;
using System.Text;
using Datos.Mapping.Usuarios;
using Entidades.Usuarios;
using Microsoft.EntityFrameworkCore;

namespace Datos
{
    public class DbContextProy : DbContext
    {
        public DbSet <UsuariosRol> UsuariosRol { get; set; }

        //CONSTRUCTOR 
        public DbContextProy(DbContextOptions<DbContextProy> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UsuariosMap());
        }
    }
}

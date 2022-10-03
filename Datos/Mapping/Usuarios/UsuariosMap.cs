using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

using Entidades.Usuarios;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Datos.Mapping.Usuarios
{
    public class UsuariosMap : IEntityTypeConfiguration<UsuariosRol>
    {
        public void Configure(EntityTypeBuilder<UsuariosRol> builder)
        {
            builder.ToTable("Usuarios")
                .HasKey(c => c.idUsuarios);//mapear la entidad Usuarios con la tabla Usuarios
        }
    }
}

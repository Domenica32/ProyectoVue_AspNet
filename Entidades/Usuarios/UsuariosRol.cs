using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Usuarios
{
    public class UsuariosRol
    {
     public int idUsuarios { get; set; }
     public int idRolUsuarios_FK { get; set; } 
    public string NombreUsuario { get; set; }
    public string ApellidoUsuario { get; set; }

    public string EmailUsuario { get; set; }
    public string PasswordUsuario_hash { get; set; }
    public string PasswordUsuario_desencrip { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoIngWeb.Models.Usuarios
{
    public class UsuariosRolViewModel
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

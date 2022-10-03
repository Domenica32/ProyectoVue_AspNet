using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoIngWeb.Models.Usuarios
{
    public class ActualizarViewModel
    {
        public int idUsuarios  { get; set; }
        [Required]
        public int idRolUsuarios_FK { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "El nombre no debe tener más de 30 caracteres y minimo debe tener 5 caracteres")]
       
        public string NombreUsuario { get; set; }
        public string ApellidoUsuario { get; set; }

        public string EmailUsuario { get; set; }
        public string PasswordUsuario_hash { get; set; }
        public string PasswordUsuario_desencrip { get; set; }
    }
}

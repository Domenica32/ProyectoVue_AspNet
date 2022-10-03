using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Datos;
using Entidades.Usuarios;
using ProyectoIngWeb.Models.Usuarios;

namespace ProyectoIngWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosRolsController : ControllerBase
    {
        private readonly DbContextProy _context;

        public UsuariosRolsController(DbContextProy context)
        {
            _context = context;
        }

        // GET: api/UsuariosRols/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<UsuariosRolViewModel>> Listar()
        {
            var usuario = await _context.UsuariosRol.ToListAsync();
            return usuario.Select(c => new UsuariosRolViewModel
            {
                idUsuarios = c.idUsuarios,
                idRolUsuarios_FK = c.idRolUsuarios_FK,
                NombreUsuario = c.NombreUsuario,
                ApellidoUsuario = c.ApellidoUsuario,
                EmailUsuario = c.EmailUsuario,
                PasswordUsuario_hash=c.PasswordUsuario_hash,
                PasswordUsuario_desencrip = c.PasswordUsuario_desencrip

            });
        }

        // GET: api/UsuariosRols/Mostrar/5
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<UsuariosRol>> Mostrar([FromRoute] int id)
        {
            var usuariosRol = await _context.UsuariosRol.FindAsync(id);

            if (usuariosRol == null)
            {
                return NotFound();
            }

            return Ok(new UsuariosRolViewModel
            {
                idUsuarios = usuariosRol.idUsuarios,
                idRolUsuarios_FK = usuariosRol.idRolUsuarios_FK,
                NombreUsuario = usuariosRol.NombreUsuario,
                ApellidoUsuario = usuariosRol.ApellidoUsuario,
                EmailUsuario = usuariosRol.EmailUsuario
            });
        }

        // PUT: api/UsuariosRols/5/Actualizar
        
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (model.idUsuarios<0)
            {
                return BadRequest();
            }

            var usuarios = await _context.UsuariosRol.FirstOrDefaultAsync(c => c.idUsuarios == model.idUsuarios);

            if (usuarios == null)
            {
                return NotFound();
            }

            usuarios.NombreUsuario = model.NombreUsuario;
            usuarios.ApellidoUsuario = model.ApellidoUsuario;
            usuarios.EmailUsuario = model.EmailUsuario;

            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //Guardar Excepcion
                return BadRequest();

            }

            return Ok();
        }

        // POST: api/UsuariosRols/Crear
        
        [HttpPost("[action]")]
        public async Task<ActionResult> Crear ([FromBody]  CrearViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            UsuariosRol usua = new UsuariosRol
            {
                idRolUsuarios_FK = model.idRolUsuarios_FK,
                NombreUsuario = model.NombreUsuario,
                ApellidoUsuario = model.ApellidoUsuario,
                EmailUsuario = model.EmailUsuario,
                PasswordUsuario_hash = model.PasswordUsuario_hash,
                PasswordUsuario_desencrip = model.PasswordUsuario_desencrip

            };
            _context.UsuariosRol.Add(usua);
            try
            {

             await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return Ok();
        }

        // DELETE: api/UsuariosRols/Eliminar/5
        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult<UsuariosRol>> Eliminar([FromRoute] int id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var usuariosRol = await _context.UsuariosRol.FindAsync(id);
            if (usuariosRol == null)
            {
                return NotFound();
            }

            _context.UsuariosRol.Remove(usuariosRol);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                return BadRequest();
            }

            

            return Ok(usuariosRol);
        }

       

        private bool UsuariosRolExists(int id)
        {
            return _context.UsuariosRol.Any(e => e.idUsuarios == id);
        }
    }
}

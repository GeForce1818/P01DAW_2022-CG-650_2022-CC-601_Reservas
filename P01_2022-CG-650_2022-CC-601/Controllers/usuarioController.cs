using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P01_2022_CG_650_2022_CC_601.Models;

namespace P01_2022_CG_650_2022_CC_601.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class usuarioController : ControllerBase
    {

        private readonly ParqueoContext _parqueoContext;

        public usuarioController(ParqueoContext ParqueoContext)
        {
            _parqueoContext = ParqueoContext;
        }


        /// <summary>
        /// EndPoint que retorna el listado de todos los usuarios
        /// </summary>
        ///
        [HttpGet]
        [Route("GetAllUsuarios/Ver todos los usuarios")]
        public IActionResult GetUsuarios()
        {
            var listaUsuarios = (from u in _parqueoContext.usuario select u).ToList();
            if (listaUsuarios.Count == 0)
            {
                return NotFound();
            }
            return Ok(listaUsuarios);
        }

        /// <summary>
        /// EndPoint que añade usuarios
        /// </summary>
        ///
        [HttpPost]
        [Route("AddUsuario")]
        public IActionResult AddUsuario([FromBody] usuario usuario)
        {
            try
            {
                _parqueoContext.Add(usuario);
                _parqueoContext.SaveChanges();
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// EndPoint que actualiza un usuario
        /// </summary>
        ///
        [HttpPut]
        [Route("actualizar/{id}")]
        public IActionResult ActualizarUsuario(int id, [FromBody] usuario usuarioModificar)
        {
            var usuarioActual = (from u in _parqueoContext.usuario
                                 where u.id == id
                                 select u).FirstOrDefault();

            if (usuarioActual == null)
            {
                return NotFound();
            }

            // Actualizar campos
            usuarioActual.nombre = usuarioModificar.nombre;
            usuarioActual.correo = usuarioModificar.correo;
            usuarioActual.nombre = usuarioModificar.nombre;
            usuarioActual.telefono = usuarioModificar.telefono;
            usuarioActual.contraseña = usuarioModificar.contraseña;
            usuarioActual.rol = usuarioModificar.rol;

            _parqueoContext.Entry(usuarioActual).State = EntityState.Modified;
            _parqueoContext.SaveChanges();

            return Ok(usuarioActual);
        }


        /// <summary>
        /// EndPoint que elimina un usuario
        /// </summary>
        ///
        [HttpDelete]
        [Route("eliminar/{id}")]
        public IActionResult EliminarUsuario(int id)
        {
            var usuario = (from u in _parqueoContext.usuario
                           where u.id == id
                           select u).FirstOrDefault();
            if (usuario == null)
            {
                return NotFound();
            }

            _parqueoContext.usuario.Remove(usuario);
            _parqueoContext.SaveChanges();

            return Ok(usuario);
        }


        /// <summary>
        /// EndPoint para validar credenciales de usuario por nombre y contraseña
        /// </summary>
        [HttpPost]
        [Route("Validar credenciales")]
        public IActionResult ValidarCredenciales([FromBody] usuario credenciales)
        {
            // Buscar usuario por nombre
            var usuario = _parqueoContext.usuario
                .FirstOrDefault(u => u.nombre == credenciales.nombre);

            if (usuario == null)
            {
                return Unauthorized(new { mensaje = "Credenciales inválidas" });
            }

            if (usuario.contraseña != credenciales.contraseña)
            {
                return Unauthorized(new { mensaje = "Credenciales inválidas" });
            }

            return Ok(new { mensaje = "Credenciales válidas", usuario = usuario });
        }

    }
}

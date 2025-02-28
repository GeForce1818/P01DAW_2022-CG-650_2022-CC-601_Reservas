using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P01_2022_CG_650_2022_CC_601.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace P01_2022_CG_650_2022_CC_601.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class reservaController : ControllerBase
    {

        private readonly ParqueoContext _ParqueoContext;

        public reservaController(ParqueoContext parqueoContext)
        {
            _ParqueoContext = parqueoContext;
        }



        [HttpGet]
        [Route("Todas las sucursales")]
        public IActionResult GetSucursales()
        {
            var sucursales = (from s in _ParqueoContext.sucursal select s).ToList();
            if (sucursales.Count == 0)
            {
                return NotFound();
            }
            return Ok(sucursales);
        }


        [HttpGet]
        [Route("Sucursal por ID/{id}")]
        public IActionResult GetSucursalPorId(int id)
        {
            var sucursal = (from s in _ParqueoContext.sucursal where s.id == id select s).FirstOrDefault();
            if (sucursal == null)
            {
                return NotFound();
            }
            return Ok(sucursal);
        }

        [HttpPost]
        [Route("agregar sucursal")]
        public IActionResult AgregarSucursal([FromBody] sucursal sucursal)
        {
            try
            {
                _ParqueoContext.sucursal.Add(sucursal);
                _ParqueoContext.SaveChanges();
                return Ok(sucursal);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("actualizar sucursal/{id}")]
        public IActionResult ActualizarSucursal(int id, [FromBody] sucursal sucursalModificar)
        {
            var sucursalActual = (from s in _ParqueoContext.sucursal where s.id == id select s).FirstOrDefault();

            if (sucursalActual == null)
            {
                return NotFound();
            }

            sucursalActual.nombre = sucursalModificar.nombre;
            sucursalActual.direccion = sucursalModificar.direccion;
            sucursalActual.telefono = sucursalModificar.telefono;
            sucursalActual.administrador = sucursalModificar.administrador;
            sucursalActual.nespacios = sucursalModificar.nespacios;

            _ParqueoContext.Entry(sucursalActual).State = EntityState.Modified;
            _ParqueoContext.SaveChanges();

            return Ok(sucursalActual);
        }


        [HttpDelete]
        [Route("eliminar sucursal/{id}")]
        public IActionResult EliminarSucursal(int id)
        {
            var sucursal = (from s in _ParqueoContext.sucursal where s.id == id select s).FirstOrDefault();
            if (sucursal == null)
            {
                return NotFound();
            }

            _ParqueoContext.sucursal.Remove(sucursal);
            _ParqueoContext.SaveChanges();

            return Ok(sucursal);
        }



        // Endpoint que retorna los espacios disponibles para una fecha
        [HttpGet]
        [Route("espacios disponibles/{fecha}")]
        public IActionResult GetEspaciosDisponibles(DateTime fecha)
        {
            
            DateOnly fechaSolo = DateOnly.FromDateTime(fecha);

           
            var reservas = _ParqueoContext.reserva
                .Where(r => r.fecha == fechaSolo)  
                .Select(r => r.idespacio)         
                .ToList();

            
            var espaciosDisponibles = _ParqueoContext.espacio
                .Where(e => !reservas.Contains(e.id))  
                .ToList();

            return Ok(espaciosDisponibles);
        }

        // Endpoint que retorna las reservas para un día específico
        [HttpGet]
        [Route("reservas por día/{fecha}")]
        public IActionResult GetReservasPorDia(DateTime fecha)
        {
            // Convertir 'fecha' (de tipo DateTime) a 'DateOnly' para la comparación
            DateOnly fechaSolo = DateOnly.FromDateTime(fecha);

            var reservas = (from r in _ParqueoContext.reserva
                            where r.fecha == fechaSolo
                            select r).ToList();

            if (reservas.Count == 0)
            {
                return NotFound();
            }
            return Ok(reservas);
        }

        // Endpoint que retorna las reservas por sucursal y rango de fechas
        [HttpGet]
        [Route("reservas por sucursal/{idSucursal}/{inicio}/{fin}")]
        public IActionResult GetReservasPorRango(int idSucursal, DateTime inicio, DateTime fin)
        {
            
            DateOnly inicioSolo = DateOnly.FromDateTime(inicio);
            DateOnly finSolo = DateOnly.FromDateTime(fin);

            var reservas = (from r in _ParqueoContext.reserva
                            where r.idsucursal == idSucursal && r.fecha >= inicioSolo && r.fecha <= finSolo
                            select r).ToList();

            if (reservas.Count == 0)
            {
                return NotFound();
            }
            return Ok(reservas);
        }

    }
}

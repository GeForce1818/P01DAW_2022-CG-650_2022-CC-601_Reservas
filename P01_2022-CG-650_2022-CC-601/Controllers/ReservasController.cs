using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P01_2022_CG_650_2022_CC_601.Models;
using Microsoft.EntityFrameworkCore;

namespace P01_2022_CG_650_2022_CC_601.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasController : ControllerBase
    {

        private readonly reserva _ReservaContext;

        public ReservasController(reserva Reservacontext)
        {
            _ReservaContext = Reservacontext;
        }
        /*
        [HttpGet]
        [Route("Espacios Disponibles/{fecha}/{hora}")]
        public IActionResult GetEspaciosDisponibles(DateOnly fecha, string hora)
        {
            // Consulta los espacios que ya están reservados en la fecha y hora dada
            var espaciosReservados = _ReservaContext.idespacio
                .Where(r => r.Fecha == fecha && r.Hora == hora)
                .Select(r => r.IdEspacio)
                .ToList();

            // Consulta los espacios disponibles (los que no están reservados)
            var espaciosDisponibles = _ReservaContext.idespacio
                .Where(e => !espaciosReservados.Contains(e.Id))
                .ToList();

            // Si no hay espacios disponibles, retorna un NotFound
            if (espaciosDisponibles.Count == 0)
            {
                return NotFound();
            }

            // Retorna los espacios disponibles
            return Ok(espaciosDisponibles);
        }
        */

        // ya no se supo que hacer 



    }



}

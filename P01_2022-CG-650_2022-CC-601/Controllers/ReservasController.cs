﻿using Microsoft.AspNetCore.Http;
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



        [HttpGet]
        [Route("Todas las reservas")]
        public IActionResult GetReservas()
        {
            var listaReservas = (from r in _ReservaContext.
                                        
            if (listaReservas.Count == 0)
            {
                return NotFound();
            }
            return Ok(listaReservas);
        }


        [HttpGet]
        [Route("Reserva Por ID/{id}")]
        public IActionResult GetReserva(int id)
        {
            var reserva = (from r in _ReservaContext.
                           where r.Id == id
                           select r).FirstOrDefault();
            if (reserva == null)
            {
                return NotFound();
            }
            return Ok(reserva);
        }
    }



}

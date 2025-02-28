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



        


       
    }



}

using MagicVilla.Datos;
using MagicVilla.Models;
using MagicVilla.VillaDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<villaDtos> Getvilla()
        {

           return VillaStore.villalist;
              
        }
        [HttpGet("id")]

        public string Getvill(int id)
        {
            var e = VillaStore.villalist.FirstOrDefault(x => x.Id == id).Nombre;
            return e ;
        }
    }
}

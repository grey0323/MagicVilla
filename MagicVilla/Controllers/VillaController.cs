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
        public ActionResult<IEnumerable<villaDtos>> Getvilla()
        {

            return Ok(VillaStore.villalist);

        }

        [HttpGet("id", Name ="Getvilla")]
        
        public ActionResult< string> Getvill(int id)
        {
            if(id == 0)
            {
                return BadRequest();

            }

            var e = VillaStore.villalist.FirstOrDefault(x => x.Id == id).Nombre;

            if(e == null)
            {
                return NotFound();
            }
            return Ok( e );
        }
        [HttpPost]

        public ActionResult<villaDtos> Crearvilla([FromBody] villaDtos villaDtos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (villaDtos == null)
            {
                return BadRequest(villaDtos);
            }

            villaDtos.Id = VillaStore.villalist.OrderByDescending(x => x.Id).FirstOrDefault().Id + 1;
            VillaStore.villalist.Add(villaDtos);

            return RedirectToAction("Getvilla", new {id = villaDtos.Id});
        
        
        }

    }
}

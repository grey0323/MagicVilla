using System.ComponentModel.DataAnnotations;

namespace MagicVilla.VillaDtos
{
    public class villaDtos
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }
        
    }
}

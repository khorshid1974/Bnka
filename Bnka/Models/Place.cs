using System.ComponentModel.DataAnnotations;

namespace Bnka.Models
{
    public class Place
    {
        public int Id { get; set; }
        [Required] public string PlaceNumber { get; set; }
        [StringLength(100)] public string Address { get; set; }


    }
}

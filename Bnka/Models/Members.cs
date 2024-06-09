using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Bnka.Models
{
    public class Members
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        public Gender Gender { get; set; }

        // relation to Parent Class
        public int ParentId { get; set; }
        public Parent? Parent { get; set; }
    }
}

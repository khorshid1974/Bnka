using System.ComponentModel.DataAnnotations;

namespace Bnka.Models
{
   public enum Gender
    {
        Male, Female
    }

    public class Parent
    {
        public int Id { get; set; }
        [Required] [StringLength(50)]
        public string FullName { get; set; }
        [Phone]
        public string Phone { get; set; }
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        public Gender Gender { get; set; }

        // relation to Place Class
        
        public int PlaceId { get; set; }
        public  Place? Place { get; set; }
        public string? Photo { get; set; }
        public int NationalityId { get; set; }
        public Nationality? Nationality { get; set; }
        public List<Members> Childern { get; set; }
        public Parent()
        {
                Childern = new List<Members>();
        }

        //public string Nationality { get; set; }

    }
}

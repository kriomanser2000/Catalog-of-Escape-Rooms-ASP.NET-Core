using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class SuperRoom
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Room Name")]
        public string Name { get; set; }
        public string About { get; set; }
        public int TimeLimit { get; set; }
        public int GroupSizeMin { get; set; }
        public int GroupSizeMax { get; set; }
        public int MinAge { get; set; }
        public string Address { get; set; }
        public int PhoneNum { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string Rate { get; set; }
        public int FearLvl { get; set; }
        public int Difficult { get; set; }
        public byte[] GalleryImg { get; set; }
    }
}

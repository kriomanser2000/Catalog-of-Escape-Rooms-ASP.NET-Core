using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Pages.ROOMS11
{
    public class RoomsInfo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        public string About { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "TimeLimit must be greater than 0")]
        public int TimeLimit { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "GroupSizeMin must be greater than 0")]
        public int GroupSizeMin { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "GroupSizeMax must be greater than 0")]
        public int GroupSizeMax { get; set; }

        [Range(1, 100, ErrorMessage = "MinAge must be between 1 and 100")]
        public int MinAge { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "PhoneNum is required")]
        public int PhoneNum { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "CompanyName is required")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Rate is required")]
        public string Rate { get; set; }

        [Range(1, 10, ErrorMessage = "FearLvl must be between 1 and 10")]
        public int FearLvl { get; set; }

        [Range(1, 10, ErrorMessage = "Difficult must be between 1 and 10")]
        public int Difficult { get; set; }

        [DataType(DataType.Upload)]
        public byte[] GalleryImg { get; set; }
    }
}

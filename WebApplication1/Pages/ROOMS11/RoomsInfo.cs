using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Pages.ROOMS11
{
    public class RoomsInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        [Range(30, 60)]
        public int TimeLimit { get; set; }
        [Range(1, int.MaxValue)]
        public int GroupSizeMin { get; set; }
        [Range(1, int.MaxValue)]
        public int GroupSizeMax { get; set; }
        [Range(1, 100)]
        public int MinAge { get; set; }
        public string Address { get; set; }
        public int PhoneNum { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string Rate { get; set; }
        [Range(1, 5)]
        public int FearLvl { get; set; }
        [Range(1, 5)]
        public int Difficult { get; set; }
        [DataType(DataType.Upload)]
        public byte[] GalleryImg { get; set; }
    }
}
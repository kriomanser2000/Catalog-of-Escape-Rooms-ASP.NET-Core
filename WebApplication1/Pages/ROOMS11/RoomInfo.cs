using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace WebApplication1.Pages.ROOMS11
{
    public class RoomInfo
    {
        public int Id { get; set; }
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
        public static List<RoomInfo> GetRooms(List<RoomInfo> _roomInfo)
        {
            return _roomInfo.Select(r => new RoomInfo
            {
                Id = r.Id,
                Name = r.Name,
                About = r.About,
                TimeLimit = r.TimeLimit,
                GroupSizeMin = r.GroupSizeMin,
                GroupSizeMax = r.GroupSizeMax,
                MinAge = r.MinAge,
                Address = r.Address,
                PhoneNum = r.PhoneNum,
                Email = r.Email,
                CompanyName = r.CompanyName,
                Rate = r.Rate,
                FearLvl = r.FearLvl,
                Difficult = r.Difficult,
                GalleryImg = r.GalleryImg,
            }).ToList();
        }
    }
}
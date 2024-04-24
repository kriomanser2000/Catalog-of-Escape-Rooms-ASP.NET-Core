using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;
using System.Xml.Linq;

namespace WebApplication1.Pages.ROOMS11
{
    public class QuestListModel : PageModel
    {
        private readonly ILogger<QuestListModel> _logger;
        public QuestListModel(ILogger<QuestListModel> logger)
        {
            _logger = logger;
        }
        public List<RoomsInfo> listRooms = new List<RoomsInfo>();
        public void OnGet()
        {
            try
            {
                string connectionString = "Data Source=DESKTOP-MQCJ73U\\SQLEXPRESS;Initial Catalog=CatalogOfRooms;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM rooms";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                RoomsInfo rooms = new RoomsInfo();
                                rooms.Id = reader.GetInt32(0);
                                rooms.Name = reader.GetString(1);
                                rooms.About = reader.GetString(2);
                                rooms.TimeLimit = reader.GetInt32(3);
                                rooms.GroupSizeMin = reader.GetInt32(4);
                                rooms.GroupSizeMax = reader.GetInt32(5);
                                rooms.MinAge = reader.GetInt32(6);
                                rooms.Address = reader.GetString(7);
                                rooms.PhoneNum = reader.GetInt32(8);
                                rooms.Email = reader.GetString(9);
                                rooms.CompanyName = reader.GetString(10);
                                rooms.Rate = reader.GetString(11);
                                rooms.FearLvl = reader.GetInt32(12);
                                rooms.Difficult = reader.GetInt32(13);
                                rooms.GalleryImg = (byte[])reader["GalleryImg"];
                                listRooms.Add(rooms);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
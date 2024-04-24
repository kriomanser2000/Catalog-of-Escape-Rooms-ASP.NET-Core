using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Pages.ROOMS11
{
    public class CreateRoomModel : PageModel
    {
        [BindProperty]
        public RoomsInfo Room { get; set; }
        public void OnGet()
        {
            Room = new RoomsInfo();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                string connectionString = "Data Source=DESKTOP-MQCJ73U\\SQLEXPRESS;Initial Catalog=CatalogOfRooms;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO rooms (Name, About, TimeLimit, GroupSizeMin, GroupSizeMax, MinAge, Address, PhoneNum, Email, CompanyName, Rate, FearLvl, Difficult, GalleryImg) VALUES (@Name, @About, @TimeLimit, @GroupSizeMin, @GroupSizeMax, @MinAge, @Address, @PhoneNum, @Email, @CompanyName, @Rate, @FearLvl, @Difficult, @GalleryImg)";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Name", Room.Name);
                        command.Parameters.AddWithValue("@About", Room.About);
                        command.Parameters.AddWithValue("@TimeLimit", Room.TimeLimit);
                        command.Parameters.AddWithValue("@GroupSizeMin", Room.GroupSizeMin);
                        command.Parameters.AddWithValue("@GroupSizeMax", Room.GroupSizeMax);
                        command.Parameters.AddWithValue("@MinAge", Room.MinAge);
                        command.Parameters.AddWithValue("@Address", Room.Address);
                        command.Parameters.AddWithValue("@PhoneNum", Room.PhoneNum);
                        command.Parameters.AddWithValue("@Email", Room.Email);
                        command.Parameters.AddWithValue("@CompanyName", Room.CompanyName);
                        command.Parameters.AddWithValue("@Rate", Room.Rate);
                        command.Parameters.AddWithValue("@FearLvl", Room.FearLvl);
                        command.Parameters.AddWithValue("@Difficult", Room.Difficult);
                        if (Room.GalleryImg != null && Room.GalleryImg.Length > 0)
                        {
                            command.Parameters.AddWithValue("@GalleryImg", Room.GalleryImg);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@GalleryImg", DBNull.Value);
                        }
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                ModelState.AddModelError(string.Empty, $"An error occurred while saving the data: {ex.Message}");
                return Page();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"An unexpected error occurred: {ex.Message}");
                return Page();
            }
            if (Request.Form.Files.Count > 0)
            {
                IFormFile file = Request.Form.Files.FirstOrDefault();
                using (var dataStream = new MemoryStream())
                {
                    file.CopyTo(dataStream);
                    Room.GalleryImg = dataStream.ToArray();
                }
            }
            else
            {
                Room.GalleryImg = null;
            }
            return RedirectToPage("/ROOMS11/QuestList");
        }
    }
}
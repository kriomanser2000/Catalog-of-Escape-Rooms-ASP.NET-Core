using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

builder.Services.AddDbContext<RoomContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Data Source=DESKTOP-MQCJ73U\\SQLEXPRESS;Initial Catalog=CatalogOfRooms;Integrated Security=True;Encrypt=True;Trust Server Certificate=True")));

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

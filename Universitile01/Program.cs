using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Universitile01.Data;
using MudBlazor.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Configuration;
using Universitile01.Services;
using Microsoft.Extensions.Configuration;
using Universitile01.Models;
using Microsoft.AspNetCore.Components.Authorization;
using static Universitile01.Pages.Dashboard;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddControllers();

//Adding Identity related services
var cs = builder.Configuration.GetConnectionString("UniDB");
builder.Services.AddDbContext<UniversitiledatabaseContext>(options => options.UseMySql(cs, ServerVersion.AutoDetect(cs)));



builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
	options.Password.RequireDigit = false;
	options.Password.RequireLowercase = false;
	options.Password.RequireUppercase = false;
	options.Password.RequiredLength = 5;
	options.Password.RequireNonAlphanumeric = false;
	options.SignIn.RequireConfirmedEmail = false;
})
.AddEntityFrameworkStores<UniversitiledatabaseContext>()
	.AddRoles<IdentityRole>()
	.AddEntityFrameworkStores<UniversitiledatabaseContext>();

builder.Services.AddScoped<AuthenticationStateProvider, IdentityValidationProvider<IdentityUser>>();
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();
builder.Services.AddMudServices();
builder.Services.AddScoped<TeacherService, TeacherService>();
builder.Services.AddScoped<UniversitiledatabaseContext>();
builder.Services.AddScoped<DataService>();
builder.Services.AddScoped<IClipboardService, ClipboardService>();




var app = builder.Build();

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

//Identity related
app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();




using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using MySqlConnector;
using Universitile01.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Runtime.InteropServices;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Authorization;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Universitile01.Areas.Identity.Pages.Account
{
    [Authorize (Roles = "Admin")]
    public class RegisterModel : PageModel
	{
		private readonly SignInManager<IdentityUser> _signInManager;
		private readonly UserManager<IdentityUser> _userManager;
		public RegisterModel(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			_signInManager = signInManager;
			_userManager = userManager;
		}
		[BindProperty]
		public InputModel Input { get; set; }
		public string ReturnUrl { get; set; }
		public async Task<IActionResult> OnPostAsync()
		{
			ReturnUrl = Url.Content("~/Identity/Account/Register");
			if (ModelState.IsValid)
			{
				var identity = new IdentityUser { UserName = Input.Email, Email = Input.Email };
				var result = await _userManager.CreateAsync(identity, Input.Password);
				var role = new IdentityRole(Input.Role);

				if (result.Succeeded)
				{
					//await _signInManager.SignInAsync(identity, isPersistent: false);
					await _userManager.AddToRoleAsync(identity, Input.Role);
					//get the connection string from secrets.json
					var connectionString = Environment.GetEnvironmentVariable("UNIDb");
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
					{
						PersonalInfo per = new PersonalInfo()
						{
							FirstName = Input.FirstName,
							LastName = Input.LastName,
							MiddleName = Input.MiddleName,
							Landline = Input.Landline,
							Mobile = Input.Mobile,
							Sex = (sbyte)Input.Sex,
							DateOfBirth = Input.DateOfBirth,
							AspnetusersId = identity.Id
						};
						connection.Open();
						string query = "INSERT INTO personal_info (date_of_birth, sex, first_name, last_name, middle_name, landline, mobile, aspnetusers_Id) VALUES ( @DateOfBirth, @Sex, @FirstName, @LastName, @MiddleName, @Landline, @Mobile, @AspNetUsersId)";
						using (MySqlCommand command = new MySqlCommand(query, connection))
						{
							command.Parameters.AddWithValue("@DateOfBirth", per.DateOfBirth);
							command.Parameters.AddWithValue("@Sex", per.Sex);
							command.Parameters.AddWithValue("@FirstName", per.FirstName);
							command.Parameters.AddWithValue("@LastName", per.LastName);
							command.Parameters.AddWithValue("@MiddleName", per.MiddleName);
							command.Parameters.AddWithValue("@Landline", per.Landline);
							command.Parameters.AddWithValue("@Mobile", per.Mobile);
							command.Parameters.AddWithValue("@AspNetUsersId", per.AspnetusersId);
							command.ExecuteNonQuery();
							connection.Close();
						}
					}
					//return LocalRedirect(ReturnUrl);
				}
			}
			return Page();
		}
		public class InputModel
		{
			[Required]
			[EmailAddress]
			public string Email { get; set; }
			[Required]
			[DataType(DataType.Password)]
			public string Password { get; set; }
			[Required]
			public string Role { get; set; }
			[Required]
			public string FirstName { get; set; }
			[Required]
			public string LastName { get; set; }
			public string? MiddleName { get; set; }
			[Required]
			public string Landline { get; set;}
			[Required]
			public string Mobile { get; set; }
			[Required]
			public int Sex { get; set; }
			[Required]
			public DateOnly DateOfBirth { get; set; }
		}
	}
}
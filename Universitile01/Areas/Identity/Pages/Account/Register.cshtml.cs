using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using MySqlConnector;
using Universitile01.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Runtime.InteropServices;
using System.Diagnostics.CodeAnalysis;

namespace Universitile01.Areas.Identity.Pages.Account
{
	public class RegisterModel : PageModel
	{
		private readonly SignInManager<IdentityUser> _signInManager;
		private readonly UserManager<IdentityUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private List<PersonalInfo> _personalInfo = new List<PersonalInfo>(); 
		private string _connectionString = "Server=universtile.mysql.database.azure.com;User ID=azureuser;Password=7TI2K6O0O1ZL6SIUE6BDMGLDK*;Database=universitiledatabase;SslMode=Required;SslCa=DigiCertGlobalRootCA.crt.pem;TlsVersion=TLS 1.2";

		public RegisterModel(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			_signInManager = signInManager;
			_userManager = userManager;
			_roleManager = roleManager;
		}

		[BindProperty]
		public InputModel Input { get; set; }

		public string ReturnUrl { get; set; }

		//public void OnGet()
		//{
		//	ReturnUrl = Url.Content("~/");
		//}

		public async Task<IActionResult> OnPostAsync()
		{
			ReturnUrl = Url.Content("~/Identity/Account/Register");

			if (ModelState.IsValid)
			{
				var identity = new IdentityUser { UserName = Input.Email, Email = Input.Email };
				var result = await _userManager.CreateAsync(identity, Input.Password);

				var role = new IdentityRole(Input.Role);
				var addRoleResult = await _roleManager.CreateAsync(role);

				var addUserRoleResult = await _userManager.AddToRoleAsync(identity, Input.Role);

				if (true/*result.Succeeded && addRoleResult.Succeeded && addUserRoleResult.Succeeded*/)
				{
					await _signInManager.SignInAsync(identity, isPersistent: false);

					using (MySqlConnection connection = new MySqlConnection(_connectionString))
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
					return LocalRedirect(ReturnUrl);

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

//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using System.ComponentModel.DataAnnotations;
//using System.Threading.Tasks;
//using Universitile01.Models;
//using MySql.Data.MySqlClient;
//using System.Data;

//namespace Universitile01.Areas.Identity.Pages.Account
//{
//	public class RegisterModel : PageModel
//	{
//		private readonly SignInManager<IdentityUser> _signInManager;
//		private readonly UserManager<IdentityUser> _userManager;
//		private readonly RoleManager<IdentityRole> _roleManager;
//		private readonly string _connectionString;

//		public RegisterModel(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
//		{
//			_signInManager = signInManager;
//			_userManager = userManager;
//			_roleManager = roleManager;
//			_connectionString = "Server=universtile.mysql.database.azure.com;User ID=azureuser;Password=7TI2K6O0O1ZL6SIUE6BDMGLDK*;Database=universitiledatabase;SslMode=Required;SslCa=DigiCertGlobalRootCA.crt.pem;TlsVersion=TLS 1.2";
//		}

//		[BindProperty]
//		public InputModel Input { get; set; }

//		public async Task<IActionResult> OnPostAsync()
//		{
//			if (ModelState.IsValid)
//			{
//				// Create the identity user
//				var identity = new IdentityUser { UserName = Input.Email, Email = Input.Email };
//				var result = await _userManager.CreateAsync(identity, Input.Password);
//				if (!result.Succeeded)
//				{
//					foreach (var error in result.Errors)
//					{
//						ModelState.AddModelError(string.Empty, error.Description);
//					}

//				}

//				// Create the role
//				var role = new IdentityRole(Input.Role);
//				var addRoleResult = await _roleManager.CreateAsync(role);
//				if (!addRoleResult.Succeeded)
//				{
//					foreach (var error in addRoleResult.Errors)
//					{
//						ModelState.AddModelError(string.Empty, error.Description);
//					}

//				}

//				// Add the user to the role
//				var addUserRoleResult = await _userManager.AddToRoleAsync(identity, Input.Role);
//				if (!addUserRoleResult.Succeeded)
//				{
//					foreach (var error in addUserRoleResult.Errors)
//					{
//						ModelState.AddModelError(string.Empty, error.Description);
//					}

//				}

//				// Create the personal info
//				var personalInfo = new PersonalInfo
//				{
//					AspnetusersId = identity.Id,
//					DateOfBirth = Input.PersonalInfo.DateOfBirth,
//					Sex = Input.PersonalInfo.Sex,
//					FirstName = Input.PersonalInfo.FirstName,
//					LastName = Input.PersonalInfo.LastName,
//					MiddleName = Input.PersonalInfo.MiddleName,
//					Landline = Input.PersonalInfo.Landline,
//					Mobile = Input.PersonalInfo.Mobile
//				};

//				// Insert the personal info into the database
//				using (var connection = new MySqlConnection(_connectionString))
//				{
//					await connection.OpenAsync();

//					var command = new MySqlCommand("INSERT INTO personal_info (date_of_birth, sex, first_name, last_name, middle_name, landline, mobile, aspnetusers_Id) VALUES (@DateOfBirth, @Sex, @FirstName, @LastName, @MiddleName, @Landline, @Mobile, @AspNetUsersId)", connection);

//					command.Parameters.AddWithValue("@DateOfBirth", personalInfo.DateOfBirth);
//					command.Parameters.AddWithValue("@Sex", personalInfo.Sex);
//					command.Parameters.AddWithValue("@FirstName", personalInfo.FirstName);
//					command.Parameters.AddWithValue("@LastName", personalInfo.LastName);
//					command.Parameters.AddWithValue("@MiddleName", Input.PersonalInfo.MiddleName);
//					command.Parameters.AddWithValue("@Landline", Input.PersonalInfo.Landline);
//					command.Parameters.AddWithValue("@Mobile", Input.PersonalInfo.Mobile);
//					command.Parameters.AddWithValue("@AspNetUsersId", personalInfo.AspnetusersId);

//					command.ExecuteNonQuery();
//					connection.Close();
//				}

//			}
//			return Page();
//		}
//		public class InputModel
//        {
//            [Required]
//            [EmailAddress]
//            public string Email { get; set; }

//            [Required]
//            [DataType(DataType.Password)]
//            public string Password { get; set; }

//            [Required]
//            public string Role { get; set; }

//            public virtual PersonalInfo PersonalInfo { get; set; } = null!;

//			public string AspNetUsersId { get; set; }

//		}


//    }
//}



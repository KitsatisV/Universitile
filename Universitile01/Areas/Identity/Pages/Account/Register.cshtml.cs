using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Universitile01.Pages;

namespace Universitile01.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public RegisterModel(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }
        public string ReturnUrl { get; set; }

		//public void OnGet()
		//{
		//    ReturnUrl = Url.Content("~/");
		//}

		public async Task<IActionResult> OnPostAsync()
		{
			//ReturnUrl = Url.Content("~/dashboard");

			if (ModelState.IsValid)
			{
				var identity = new IdentityUser { UserName = Input.Email, Email = Input.Email };
				var result = await _userManager.CreateAsync(identity, Input.Password);

				if (result.Succeeded)
				{
					// Assign role to user
					var roleResult = await _userManager.AddToRoleAsync(identity, Input.Role);
					if (!roleResult.Succeeded)
					{
						ModelState.AddModelError(string.Empty, "Failed to assign role to user.");
						return Page();
					}

					//await _signInManager.SignInAsync(identity, isPersistent: false);
					//return LocalRedirect(ReturnUrl);
				}

				foreach (var error in result.Errors)
				{
					ModelState.AddModelError(string.Empty, error.Description);
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
        }
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.ComponentModel.DataAnnotations;
using Universitile01.Models;

namespace Universitile01.Areas.Identity.Pages.Account
{
    public class LoginModel : PageModel
    {
		private readonly SignInManager<IdentityUser> _signInManager;
        public LoginModel(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [BindProperty]
		public InputModel Input { get; set; }
		public string ReturnUrl { get; set; }

		public async Task<IActionResult> OnPostAsync()
		{
			ReturnUrl = Url.Content("~/dashboard");

			if (ModelState.IsValid)
			{
				var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, isPersistent: false, lockoutOnFailure: false);

				if (result.Succeeded)
				{
					return LocalRedirect(ReturnUrl);
				}

				ModelState.AddModelError("", "Email and/or Password incorrect!");
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
		}
	}
}

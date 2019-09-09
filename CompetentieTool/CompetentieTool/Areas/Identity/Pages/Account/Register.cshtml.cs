using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using CompetentieTool.Models.Identities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace CompetentieTool.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Bedrijfsnaam is verplicht in te vullen")]
            public string Bedrijfsnaam { get; set; }

            [Display(Name = "BTW/Bedrijfsnummer")]
            [Required(ErrorMessage = "BTW/Bedrijfsnummer is verplicht in te vullen")]
            public string Btwnummer { get; set; }

            [Required(ErrorMessage = "Voornaam is verplicht in te vullen")]
            public string Voornaam { get; set; }

            [Required(ErrorMessage = "Familienaam is verplicht in te vullen")]
            public string Achternaam { get; set; }

            [Required(ErrorMessage = "Geboortedatum is verplicht in te vullen")]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
            public DateTime Geboortedatum { get; set; }

            [Required(ErrorMessage = "Huisnummer is verplicht in te vullen")]
            public string Huisnummer { get; set; }

            [Required(ErrorMessage = "Straat is verplicht in te vullen")]
            public string Straat { get; set; }

            [Required(ErrorMessage = "Postcode is verplicht in te vullen")]
            public string Postcode { get; set; }

            [Required(ErrorMessage = "Gemeente is verplicht in te vullen")]
            public string Gemeente { get; set; }

            [Required(ErrorMessage = "Nationaliteit is verplicht in te vullen")]
            public string Nationaliteit { get; set; }

            [Required(ErrorMessage = "Geslacht is verplicht in te vullen")]
            public string Geslacht { get; set; }

            [Display(Name = "Gsm nummer")]
            //[RegularExpression(@"^\+32[0-9]{9}$", ErrorMessage = "Een gsm nummer is van de vorm: +32470253698")]
            public string GsmNummer { get; set; }

            [Required(ErrorMessage = "Email is verplicht in te vullen")]
            [Display(Name = "Email")]
            [EmailAddress(ErrorMessage = "Dit is geen geldig emailadres")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "Het {0} moet minstens {2} en maximaal {1} karakters lang zijn.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Wachtwoord")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Wachwoord bevestigen")]
            [Compare("Password", ErrorMessage = "Het wachwoord en de wachwoord bevestiging komen niet overeen.")]
            public string ConfirmPassword { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = Input.Email, Email = Input.Email, SecurityStamp = Guid.NewGuid().ToString("D") };
                user.SetGegevensWerkgever(Input);
                var result = await _userManager.CreateAsync(user, Input.Password);
                await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "Werkgever"));
                
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}

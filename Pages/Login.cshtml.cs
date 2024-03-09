using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using e_learning.Models; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace e_learning.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ELearningContext _eLearningContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        [BindProperty]
        public User User { get; set; }

        public string ErrorMessage { get; set; }

        public LoginModel(ELearningContext _eLearningContext, IHttpContextAccessor httpContextAccessor, IConfiguration configuration) // Replace YourDbContext with your actual DbContext class name
        {
            this._eLearningContext = _eLearningContext;
            this._httpContextAccessor = httpContextAccessor;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = _eLearningContext.Users.FirstOrDefault(u => u.Username == User.Username && u.Password == User.Password);

            if (user != null)
            {
                // Create claims for the user
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Email, user.Email),
                };

                // Create a security key
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"])); // Read secret key from configuration

                // Create a signing credential using the security key
                var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                // Create a token descriptor
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddHours(1), // Token expiration time
                    SigningCredentials = signingCredentials
                };

                // Create a token handler
                var tokenHandler = new JwtSecurityTokenHandler();

                // Create a token
                var token = tokenHandler.CreateToken(tokenDescriptor);

                // Write the token as a string
                var tokenString = tokenHandler.WriteToken(token);

                // Store the token in session
                _httpContextAccessor.HttpContext.Session.SetString("JwtToken", tokenString);

                // Redirect to home page or any other page
                return RedirectToPage("/Index");
            }
            else
            {
                ErrorMessage = "Invalid username or password.";
                return Page();
            }
        }
    }
}

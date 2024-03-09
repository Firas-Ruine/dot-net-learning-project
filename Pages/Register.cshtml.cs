using e_learning.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;

namespace e_learning.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly ELearningContext? _context;
        public RegisterModel(ELearningContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User UserData { get; set; }
        public string Error { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (UserData.Username.IsNullOrEmpty())
            {
                Error = "UserName is Required";
                return Page();
            }
            if (UserData.Password.IsNullOrEmpty() || Request.Form["confirmPassword"].IsNullOrEmpty()  || UserData.Password != Request.Form["confirmPassword"])
            {
                Error = "Invalide password";
                return Page();
            }
            if (UserData.Email.IsNullOrEmpty())
            {
                Error = "Invalide Email";
                return Page();
            }
            if (UserData.Firstname.IsNullOrEmpty())
            {
                Error = "First Name is Required";
                return Page();
            }
            if (UserData.Lastname.IsNullOrEmpty())
            {
                Error = "last Name is Required";
                return Page();
            }
            if (Error.IsNullOrEmpty())
            {
                int role_id = int.Parse(Request.Form["role"]);
                Role role =  _context.Roles.FirstOrDefault(r => r.RoleId == role_id);
                UserData.Role = role;

                //save to db
                _context.Users.Add(UserData);
                _context.SaveChanges();
                return RedirectToPage("/Index");
            }
            
            return Page();

        }
    }
}

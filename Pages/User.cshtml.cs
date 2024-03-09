using e_learning.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace e_learning.Pages
{
    public class UserModel : PageModel
    {
        private readonly ELearningContext _eLearningContext;

        public UserModel(ELearningContext eLearningContext)
        {
            _eLearningContext = eLearningContext;
        }

        public IList<User> Users { get; set; }
        public IList<Role> Roles { get; set; }
        public void OnGet(string? roleFilter)
        {
            IQueryable<User> usersQuery = _eLearningContext.Users.Include(u => u.Role);

            if (!roleFilter.IsNullOrEmpty())
            {
                usersQuery = usersQuery.Where(u => u.Role.RoleName == roleFilter);
            }

            Users = usersQuery.ToList();
            Roles = _eLearningContext.Roles.ToList();
        }
    }
}

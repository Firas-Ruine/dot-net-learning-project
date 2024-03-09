using e_learning.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

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
        public void OnGet()
        {
            Users = _eLearningContext.Users
                .Include(u => u.Role)
                .ToList();

        }
    }
}

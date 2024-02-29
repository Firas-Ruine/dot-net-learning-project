using e_learning.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace e_learning.Pages
{
    public class CoursesModel : PageModel
    {
        private readonly ELearningContext _context;
        public CoursesModel(ELearningContext context)
        {
            _context = context;
        }

        public List<Course> courses { get; set; }
        public void OnGet()
        {
            courses = _context.Courses
                .Include(c => c.Instructor)
                .Include(c => c.Assignments)
                .ThenInclude(a => a.Submissions)
                .ToList();
        }
    }
}

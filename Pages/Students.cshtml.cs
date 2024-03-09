using e_learning.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace e_learning.Pages
{
    public class StudentsModel : PageModel
    {

        private readonly ELearningContext _context;
        public StudentsModel(ELearningContext context)
        {
            _context = context;
        }

        public List<User> Students { get; set; }
        public List<Course> RelatedCourses { get; set; }
        public void OnGet(string? studentName , string? hasCourses)
        {
            IQueryable<User> StudentsQuery = _context
                .Users
                .Include(s => s.Role)
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Course)
                .ThenInclude(c => c.Assignments)
                .ThenInclude(a => a.Submissions)
                .Where(s => s.Role.RoleName == "student");

            if (!studentName.IsNullOrEmpty())
            {
                StudentsQuery = StudentsQuery.Where(s => s.Firstname.Contains(studentName) 
                || s.Lastname.Contains(studentName)
                ||s.Username.Contains(studentName));
            }
            if (!hasCourses.IsNullOrEmpty() && hasCourses == "1")
            {
                StudentsQuery = StudentsQuery.Where(s => s.Enrollments.Any());
            }
            else
            {
                StudentsQuery = StudentsQuery.Where(s => s.Enrollments.Count() <=0);
            }
            Students = StudentsQuery.ToList();
        }
    }
}

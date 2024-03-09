using e_learning.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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
        public void OnGet(string? courseName ,string? startDate, string? endDate)
        {
            IQueryable<Course>  coursesQuery = _context.Courses
                .Include(c => c.Instructor)
                .Include(c => c.Assignments)
                .ThenInclude(a => a.Submissions);

            if (!courseName.IsNullOrEmpty())
            {
                coursesQuery = coursesQuery.Where(c => c.CourseName.Contains(courseName) || c.Description.Contains(courseName));
            }

            if (!startDate.IsNullOrEmpty() && endDate.IsNullOrEmpty())
            {
                
                coursesQuery = coursesQuery.Where(c => c.StartDate >= DateOnly.Parse(startDate));

            }else if(!endDate.IsNullOrEmpty() && startDate.IsNullOrEmpty())
            {
                coursesQuery = coursesQuery.Where(c => c.EndDate <= DateOnly.Parse(endDate));
            }
            else if(!startDate.IsNullOrEmpty() && !endDate.IsNullOrEmpty())
            {
                coursesQuery = coursesQuery.Where(c => c.StartDate >= DateOnly.Parse(startDate) && c.EndDate <= DateOnly.Parse(endDate));
            }

            courses = coursesQuery.ToList();

        }
    }
}

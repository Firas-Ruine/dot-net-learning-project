using e_learning.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace e_learning.Pages
{
    public class AssignementsModel : PageModel
    {
        private readonly ELearningContext _context;
        public AssignementsModel(ELearningContext context)
        {
            _context = context;
        }
        public List<Assignment> Assignments { get; set; }

        // Add date filter
        public DateOnly? DueDate { get; set; }

        // Filter function for the date
        public void OnGet(string? dueDate)
        {
            IQueryable<Assignment> assignmentsQuery = _context.Assignments
                .Include(a => a.Course)
                .ThenInclude(c => c.Instructor)
                .Include(a => a.Submissions);

            if (!dueDate.IsNullOrEmpty())
            {
                DueDate = DateOnly.Parse(dueDate);
                assignmentsQuery = assignmentsQuery.Where(a => a.DueDate == DueDate);
            }

            Assignments = assignmentsQuery.ToList();
        }   
    }
}

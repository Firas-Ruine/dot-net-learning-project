using e_learning.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace e_learning.Pages
{
    public class CourseModel : PageModel
    {
        private readonly ELearningContext _eLearningContext;

        public CourseModel(ELearningContext eLearningContext)
        {
            _eLearningContext = eLearningContext;
        }

        public IList<Course> Courses { get; set; }

        public async Task<IActionResult> OnGetAsync(int instructorId)
        {
            Courses = _eLearningContext.Courses
                .Where(c => c.InstructorId == instructorId)
                .ToList();

            return Page();
        }
    }
}

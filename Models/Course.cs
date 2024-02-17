using System;
using System.Collections.Generic;

namespace e_learning.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string CourseName { get; set; } = null!;

    public string? Description { get; set; }

    public int? InstructorId { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public virtual ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();

    public virtual ICollection<DiscussionTopic> DiscussionTopics { get; set; } = new List<DiscussionTopic>();

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual User? Instructor { get; set; }

    public virtual ICollection<Quiz> Quizzes { get; set; } = new List<Quiz>();
}

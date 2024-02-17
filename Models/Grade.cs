using System;
using System.Collections.Generic;

namespace e_learning.Models;

public partial class Grade
{
    public int GradeId { get; set; }

    public int? SubmissionId { get; set; }

    public int? InstructorId { get; set; }

    public decimal? Grade1 { get; set; }

    public string? Feedback { get; set; }

    public DateOnly? GradingDate { get; set; }

    public virtual User? Instructor { get; set; }

    public virtual Submission? Submission { get; set; }
}

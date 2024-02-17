using System;
using System.Collections.Generic;

namespace e_learning.Models;

public partial class Quiz
{
    public int QuizId { get; set; }

    public int? CourseId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public virtual Course? Course { get; set; }

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();

    public virtual ICollection<QuizSubmission> QuizSubmissions { get; set; } = new List<QuizSubmission>();
}

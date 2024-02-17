using System;
using System.Collections.Generic;

namespace e_learning.Models;

public partial class Assignment
{
    public int AssignmentId { get; set; }

    public int? CourseId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public DateOnly? DueDate { get; set; }

    public virtual Course? Course { get; set; }

    public virtual ICollection<Submission> Submissions { get; set; } = new List<Submission>();
}

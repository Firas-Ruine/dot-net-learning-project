using System;
using System.Collections.Generic;

namespace e_learning.Models;

public partial class Submission
{
    public int SubmissionId { get; set; }

    public int? AssignmentId { get; set; }

    public int? UserId { get; set; }

    public DateOnly? SubmissionDate { get; set; }

    public string? FilePath { get; set; }

    public virtual Assignment? Assignment { get; set; }

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

    public virtual User? User { get; set; }
}

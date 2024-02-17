using System;
using System.Collections.Generic;

namespace e_learning.Models;

public partial class QuizSubmission
{
    public int SubmissionId { get; set; }

    public int? UserId { get; set; }

    public int? QuizId { get; set; }

    public DateOnly? SubmissionDate { get; set; }

    public decimal? Score { get; set; }

    public virtual Quiz? Quiz { get; set; }

    public virtual User? User { get; set; }
}

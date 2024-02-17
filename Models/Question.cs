using System;
using System.Collections.Generic;

namespace e_learning.Models;

public partial class Question
{
    public int QuestionId { get; set; }

    public int? QuizId { get; set; }

    public string? Type { get; set; }

    public string? QuestionText { get; set; }

    public string? CorrectAnswer { get; set; }

    public virtual Quiz? Quiz { get; set; }
}

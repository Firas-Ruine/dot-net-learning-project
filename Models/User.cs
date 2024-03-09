using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace e_learning.Models;

public partial class User
{
    public int UserId { get; set; }
    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    public string Email { get; set; } = null!;

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public int RoleId { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual ICollection<DiscussionPost> DiscussionPosts { get; set; } = new List<DiscussionPost>();

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

    public virtual ICollection<QuizSubmission> QuizSubmissions { get; set; } = new List<QuizSubmission>();

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<Submission> Submissions { get; set; } = new List<Submission>();
}

using System;
using System.Collections.Generic;

namespace e_learning.Models;

public partial class DiscussionTopic
{
    public int TopicId { get; set; }

    public int? CourseId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public virtual Course? Course { get; set; }

    public virtual ICollection<DiscussionPost> DiscussionPosts { get; set; } = new List<DiscussionPost>();
}

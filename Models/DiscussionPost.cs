using System;
using System.Collections.Generic;

namespace e_learning.Models;

public partial class DiscussionPost
{
    public int PostId { get; set; }

    public int? TopicId { get; set; }

    public int? UserId { get; set; }

    public string? PostText { get; set; }

    public DateOnly? PostDate { get; set; }

    public virtual DiscussionTopic? Topic { get; set; }

    public virtual User? User { get; set; }
}

using System;

namespace RedditClone;

public class Comments
{
    public int Id { get; set; }
    public int Comment_id { get; set; }
    public int Topic_id { get; set; }
    public int Thread_id { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public int Rating { get; set; }
}

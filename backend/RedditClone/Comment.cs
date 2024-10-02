using System;

namespace RedditClone;

public class Comment
{
    public int Id { get; set; }
    public int Title_Id { get; set; }
    public int Thread_Id { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public int Rating { get; set; }
}

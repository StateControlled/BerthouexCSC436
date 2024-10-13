using System;

namespace RedditClone;

public class Topic
{
    public int Id { get; set; }
    public int Topic_id { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public int Rating { get; set; }
}

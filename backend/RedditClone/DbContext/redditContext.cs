using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace RedditClone;

// Set this up before creating the actual database
public class redditContext : DbContext
{
    // handles to data
    public DbSet<Comments> Comments { get; set; }
    public DbSet<Topic> Topics { get; set; }

    // instantiate the database
    public redditContext()
    {
            // var folder = Environment.SpecialFolder.LocalAppicationData;
            // var path = Environment.GetFolderPath(folder);
            // DbPath = System.IO.Path.Join(path, "reddit.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseSqlite($"Data Source=reddit.db");
    
}

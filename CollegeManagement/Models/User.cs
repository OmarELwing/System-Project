using System;
using System.Collections.Generic;

namespace CollegeManagement.Models;

public partial class User
{
    public long Id { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Role { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual Doctor? Doctor { get; set; }

    public virtual Student? Student { get; set; }
}

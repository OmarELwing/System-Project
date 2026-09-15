using System;
using System.Collections.Generic;

namespace CollegeManagement.Models;

public partial class Classroom
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public int? Capacity { get; set; }

    public virtual ICollection<SubjectDoctor> SubjectDoctors { get; set; } = new List<SubjectDoctor>();
}

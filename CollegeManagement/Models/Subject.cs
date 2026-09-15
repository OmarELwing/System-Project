using System;
using System.Collections.Generic;

namespace CollegeManagement.Models;

public partial class Subject
{
    public long Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Assessment> Assessments { get; set; } = new List<Assessment>();

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual ICollection<SubjectDoctor> SubjectDoctors { get; set; } = new List<SubjectDoctor>();
}

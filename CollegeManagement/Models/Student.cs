using System;
using System.Collections.Generic;

namespace CollegeManagement.Models;

public partial class Student
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public string StudentCode { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public virtual ICollection<AssessmentGrade> AssessmentGrades { get; set; } = new List<AssessmentGrade>();

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual User User { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace CollegeManagement.Models;

public partial class Assessment
{
    public long Id { get; set; }

    public long SubjectId { get; set; }

    public long DoctorId { get; set; }

    public string Type { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? DueDate { get; set; }

    public virtual ICollection<AssessmentGrade> AssessmentGrades { get; set; } = new List<AssessmentGrade>();

    public virtual Doctor Doctor { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;
}

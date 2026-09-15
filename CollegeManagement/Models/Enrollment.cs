using System;
using System.Collections.Generic;

namespace CollegeManagement.Models;

public partial class Enrollment
{
    public long Id { get; set; }

    public long StudentId { get; set; }

    public long SubjectId { get; set; }

    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    public virtual ICollection<PerformanceEvaluation> PerformanceEvaluations { get; set; } = new List<PerformanceEvaluation>();

    public virtual Student Student { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;
}

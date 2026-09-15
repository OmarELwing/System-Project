using System;
using System.Collections.Generic;

namespace CollegeManagement.Models;

public partial class AssessmentGrade
{
    public long Id { get; set; }

    public long AssessmentId { get; set; }

    public long StudentId { get; set; }

    public decimal Grade { get; set; }

    public virtual Assessment Assessment { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}

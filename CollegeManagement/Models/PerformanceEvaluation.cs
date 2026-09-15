using System;
using System.Collections.Generic;

namespace CollegeManagement.Models;

public partial class PerformanceEvaluation
{
    public long Id { get; set; }

    public long EnrollmentId { get; set; }

    public long DoctorId { get; set; }

    public decimal Score { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Doctor Doctor { get; set; } = null!;

    public virtual Enrollment Enrollment { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace CollegeManagement.Models;

public partial class Attendance
{
    public long Id { get; set; }

    public long EnrollmentId { get; set; }

    public long SubjectDoctorId { get; set; }

    public DateOnly Date { get; set; }

    public string Status { get; set; } = null!;

    public virtual Enrollment Enrollment { get; set; } = null!;

    public virtual SubjectDoctor SubjectDoctor { get; set; } = null!;
}

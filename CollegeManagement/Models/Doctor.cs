using System;
using System.Collections.Generic;

namespace CollegeManagement.Models;

public partial class Doctor
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public string DoctorCode { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public virtual ICollection<Assessment> Assessments { get; set; } = new List<Assessment>();

    public virtual ICollection<PerformanceEvaluation> PerformanceEvaluations { get; set; } = new List<PerformanceEvaluation>();

    public virtual ICollection<SubjectDoctor> SubjectDoctors { get; set; } = new List<SubjectDoctor>();

    public virtual User User { get; set; } = null!;
}

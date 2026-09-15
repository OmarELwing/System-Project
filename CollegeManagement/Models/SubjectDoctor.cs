using System;
using System.Collections.Generic;

namespace CollegeManagement.Models;

public partial class SubjectDoctor
{
    public long Id { get; set; }

    public long SubjectId { get; set; }

    public long DoctorId { get; set; }

    public string DayOfWeek { get; set; } = null!;

    public TimeOnly? StartTime { get; set; }

    public TimeOnly? EndTime { get; set; }

    public long? ClassroomId { get; set; }

    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    public virtual Classroom? Classroom { get; set; }

    public virtual Doctor Doctor { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;
}

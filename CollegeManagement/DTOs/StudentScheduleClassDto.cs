namespace CollegeManagement.DTOs
{
    public class StudentScheduleClassDto
    {
        public TimeOnly? StartTime { get; set; }
        public TimeOnly? EndTime { get; set; }
        public string SubjectName { get; set; } = null!;
        public string SubjectCode { get; set; } = null!;
        public string DoctorName { get; set; } = null!;
        public string Classroom { get; set; } = null!;
    }
}

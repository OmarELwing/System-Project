namespace CollegeManagement.DTOs
{
    public class StudentSubjectDoctorDto
    {
        public string DoctorName { get; set; } = null!;
        public string Day { get; set; } = null!;
        public TimeOnly? StartTime { get; set; }
        public TimeOnly? EndTime { get; set; }
        public string Classroom { get; set; } = null!;
    }
}
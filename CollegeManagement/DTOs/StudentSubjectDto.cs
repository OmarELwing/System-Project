namespace CollegeManagement.DTOs
{
    public class StudentSubjectDto
    {
        public string SubjectName { get; set; } = null!;
        public int CreditHours { get; set; }
        public string SubjectCode { get; set; } = null!;
        public string DoctorName { get; set; } = null!;
        public string Day { get; set; } = null!;
        public TimeOnly? StartTime { get; set; }
        public string Classroom { get; set; } = null!;
    }
}
namespace CollegeManagement.DTOs
{
    public class StudentSubjectDetailsDto
    {
        public string SubjectName { get; set; } = null!;
        public string SubjectCode { get; set; } = null!;
        public int CreditHours { get; set; }
        public string Description { get; set; } = null!;
        public List<StudentSubjectDoctorDto> Doctors { get; set; } = new();
    }
}
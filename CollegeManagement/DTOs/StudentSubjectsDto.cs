namespace CollegeManagement.DTOs
{
    public class StudentSubjectsDto
    {
        public int SubjectsCount { get; set; }
        public List<StudentSubjectDto> Subjects { get; set; } = new();
    }
}
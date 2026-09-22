namespace CollegeManagement.DTOs
{
    public class StudentScheduleDayDto
    {
        public string Day { get; set; } = null!;
        public List<StudentScheduleClassDto> Classes { get; set; } = new();
    }
}

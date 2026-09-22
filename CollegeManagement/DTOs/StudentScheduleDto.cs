namespace CollegeManagement.DTOs
{
    public class StudentScheduleDto
    {
        public string StudentName { get; set; } = null!;
        public DateOnly Today { get; set; }
        public string TodayDay { get; set; } = null!;
        public List<StudentScheduleDayDto> Days { get; set; } = new();
    }
}
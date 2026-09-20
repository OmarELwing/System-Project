namespace CollegeManagement.DTOs
{
    public class TodayScheduleDto
    {
        public string SubjectName { get; set; } = null!;
        public string Classroom { get; set; } = null!;
        public TimeOnly? StartTime { get; set; }
        public TimeOnly? EndTime { get; set; }
    }
}

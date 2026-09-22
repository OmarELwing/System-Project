namespace CollegeManagement.DTOs
{
    public class StudentDashboardDto
    {
        public string StudentName { get; set; } = null!;
        public string StudentCode { get; set; } = null!;
        public string TimeUntil { get; set; } = null!;
        public TodayScheduleDto? TodayClass { get; set; }
    }
}
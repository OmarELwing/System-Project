namespace CollegeManagement.DTOs
{
    public class DoctorDashboardDto
    {
        public string DoctorName { get; set; } = null!;
        public int SubjectsCount { get; set; }
        public List<TodayScheduleDto> TodaySchedule { get; set; } = new();
    }
}

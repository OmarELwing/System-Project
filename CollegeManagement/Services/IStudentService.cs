using CollegeManagement.DTOs;

namespace CollegeManagement.Services
{
    public interface IStudentService
    {
        Task<StudentScheduleDto?> GetScheduleAsync(long studentId);
        Task<StudentSubjectsDto?> GetSubjectsAsync(long studentId);
        Task<StudentSubjectDetailsDto?> GetSubjectDetailsAsync(long studentId, long subjectId);
        Task<StudentDashboardDto?> GetDashboardAsync(long studentId);
    }
}
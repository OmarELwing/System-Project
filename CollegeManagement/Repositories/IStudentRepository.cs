using CollegeManagement.Models;

namespace CollegeManagement.Repositories
{
    public interface IStudentRepository
    {
        Task<Student?> GetStudentScheduleDataAsync(long studentId);
        Task<Student?> GetStudentSubjectsDataAsync(long studentId);
        Task<Student?> GetStudentSubjectDetailsDataAsync(long studentId, long subjectId);
        Task<Student?> GetStudentDashboardDataAsync(long studentId);
    }
}
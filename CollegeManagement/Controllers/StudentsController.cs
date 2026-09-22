using CollegeManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace CollegeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("{studentId}/schedule")]
        public async Task<ActionResult> GetSchedule(long studentId)
        {
            var schedule = await _studentService.GetScheduleAsync(studentId);

            if (schedule == null)
            {
                return NotFound("Student not found.");
            }

            return Ok(schedule);
        }

        [HttpGet("{studentId}/subjects")]
        public async Task<ActionResult> GetSubjects(long studentId)
        {
            var subjects = await _studentService.GetSubjectsAsync(studentId);

            if (subjects == null)
            {
                return NotFound("Student not found.");
            }

            return Ok(subjects);
        }

        [HttpGet("{studentId}/subjects/{subjectId}")]
        public async Task<ActionResult> GetSubjectDetails(long studentId, long subjectId)
        {
            var subject = await _studentService.GetSubjectDetailsAsync(studentId, subjectId);

            if (subject == null)
            {
                return NotFound("Student or subject not found.");
            }

            return Ok(subject);
        }

        [HttpGet("{studentId}/dashboard")]
        public async Task<ActionResult> GetDashboard(long studentId)
        {
            var dashboard = await _studentService.GetDashboardAsync(studentId);

            if (dashboard == null)
            {
                return NotFound("Student not found.");
            }

            return Ok(dashboard);
        }
    }
}
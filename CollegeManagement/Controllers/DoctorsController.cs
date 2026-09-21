using CollegeManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CollegeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorsController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }
        [HttpGet("dashboard")]
        public async Task<ActionResult> GetDashboard(long doctorId)
        {
            var dashboard = await _doctorService.GetDashboardAsync(doctorId);
            if (dashboard == null)
            {
                return NotFound("Doctor not found.");
            }
            return Ok(dashboard);
        }
        [HttpGet("subjects")]
        public async Task<ActionResult> GetSubjects(long doctorId)
        {
            var subjects = await _doctorService.GetSubjectAsync(doctorId);
            if (subjects == null)
            {
                return NotFound("There are no subjects yet.");
            }
            return Ok(subjects);
        }
    }
}

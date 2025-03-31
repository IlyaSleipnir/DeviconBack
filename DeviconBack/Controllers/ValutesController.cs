using DeviconBack.Data;
using DeviconBack.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace DeviconBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValutesController : ControllerBase
    {
        private readonly ICbrService _cbrService;

        public ValutesController(ICbrService cbrService)
        {
            _cbrService = cbrService;
        }

        [HttpGet("latest")]
        public async Task<IActionResult> GetLatestCourses()
        {
            var result = await _cbrService.GetLatestCourses();
            if (result.IsNullOrEmpty())
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("by-date")]
        public async Task<IActionResult> GetCoursesByDate([FromQuery] DateTime fromDate, [FromQuery] DateTime toDate)
        {
            var result = await _cbrService.GetCoursesInInterval(fromDate.Date, toDate.Date);
            if (result.IsNullOrEmpty())
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}

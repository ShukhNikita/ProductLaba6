using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Product.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActivityTypeController : Controller
    {
        private readonly ProductAnalysisContext _context;
        public ActivityTypeController(ProductAnalysisContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActivityType>>> Get()
        {
            var result = await _context.ActivityTypes.ToListAsync();
            return Ok(result);
        }
    }
}

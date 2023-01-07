using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Product.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OwnershipFormController : Controller
    {
        private readonly ProductAnalysisContext _context;
        public OwnershipFormController(ProductAnalysisContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OwnershipForm>>> Get()
        {
            var result = await _context.OwnershipForms.ToListAsync();
            return Ok(result);
        }
    }
}

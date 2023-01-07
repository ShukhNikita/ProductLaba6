using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Product.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : Controller
    {
        private readonly ProductAnalysisContext _context;
        public CompanyController(ProductAnalysisContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> Get()
        {
            var result = await _context.Companies.Include(a => a.ActivityType).Include(o => o.OwnershipForm).ToListAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int? id)
        {
            Company company = await _context.Companies.Include(a => a.ActivityType).Include(o => o.OwnershipForm).FirstOrDefaultAsync(c => c.Id == id);
            if (company != null)
            {
                return Ok(company);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Company company)
        {
            if (ModelState.IsValid)
            {
                if (company != null)
                {
                    _context.Companies.Add(company);
                    await _context.SaveChangesAsync();
                    return Ok(company);
                }
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult> Update(Company company)
        {
            if (ModelState.IsValid)
            {
                if (company != null)
                {
                    if (await _context.Companies.AnyAsync(c => c.Id == company.Id))
                    {
                        _context.Update(company);
                        await _context.SaveChangesAsync();
                        return Ok(company);
                    }
                    return NotFound();
                }
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int? id)
        {
            Company company = await _context.Companies.FirstOrDefaultAsync(c => c.Id == id);
            if (company != null)
            {
                _context.Companies.Remove(company);
                await _context.SaveChangesAsync();
                return Ok(company);
            }
            return NotFound();
        }
    }
}

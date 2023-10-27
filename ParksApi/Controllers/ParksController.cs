using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParksApi.Models;

namespace ParksApi.Controllers
{
  [Route("api/[controller]")] // specifies that the base request URL for ParksController is /api/parks
  [ApiController]
  public class ParksController : ControllerBase
  {
    private readonly ParksApiContext _db;

    public ParksController(ParksApiContext db)
    {
      _db = db;
    }

    // GET api/parks
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Park>>> Get()
    {
      return await _db.Parks.ToListAsync();
    }

    // GET api/parks/2
    [HttpGet("{id}")]
    public async Task<ActionResult<Park>> GetPark(int id)
    {
      Park specifiedPark = await _db.Parks.FindAsync(id);

      if(specifiedPark == null)
      {
        return NotFound();
      } 

      return specifiedPark;
    }

    // POST api/parks
    [HttpPost]
    public async Task<ActionResult<Park>> Post(Park newEntry)
    {
      _db.Parks.Add(newEntry);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetPark), new { id = newEntry.ParkId }, newEntry);
    }
  }
}
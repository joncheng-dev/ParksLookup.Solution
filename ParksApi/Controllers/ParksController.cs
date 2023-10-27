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
    public async Task<ActionResult<IEnumerable<Park>>> Get(string name, string feeRequired, string status, string campingAllowed, string dogsAllowed)
    {
      IQueryable<Park> query = _db.Parks.AsQueryable();

      if(name != null)
      {
        query = query.Where(entry => entry.Name == name);
      }

      if(feeRequired != null)
      {
        query = query.Where(entry => entry.FeeRequired == feeRequired);        
      }

      if(status != null)
      {
        query = query.Where(entry => entry.Status == status);
      }

      if(campingAllowed != null)
      {
        query = query.Where(entry => entry.CampingAllowed == campingAllowed);
      }

      if(dogsAllowed != null)
      {
        query = query.Where(entry => entry.DogsAllowed == dogsAllowed);
      }

      return await query.ToListAsync();      
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

    // PUT api/parks/2
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Park editedEntry)
    {
      if(id != editedEntry.ParkId)
      {
        return BadRequest();
      }

      _db.Parks.Update(editedEntry);

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if(!ParkExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    private bool ParkExists(int id)
    {
      return _db.Parks.Any(entry => entry.ParkId == id);
    }

    // DELETE api/Parks/3
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePark(int id)
    {
      Park targetPark = await _db.Parks.FindAsync(id);
      if(targetPark == null)
      {
        return NotFound();
      }

      _db.Parks.Remove(targetPark);
      await _db.SaveChangesAsync();

      return NoContent();
    }
  }
}
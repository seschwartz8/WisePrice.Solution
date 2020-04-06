using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WisePriceApi.Models;

namespace WisePriceApi.Controllers
{
  [Route("/[controller]")]
  [ApiController]
  public class LocationsController : ControllerBase
  {
    private WisePriceApiContext _db;

    public LocationsController(WisePriceApiContext db)
    {
      _db = db;
    }

    // GET api/locations
    [HttpGet]
    public ActionResult<IEnumerable<Location>> Get(string location)
    {
      var query  = _db.Locations.AsQueryable();

      if (location != null)
      {
        query = query.Where(entry => entry.ZipCode.ToString() == location);
      }

      return query.ToList();
    }

    // GET api/locations/5
    [HttpGet("{id}")]
    public ActionResult<string> Get(int id)
    {
      return "value";
    }

    // POST api/locations
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/locations/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/locations/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}

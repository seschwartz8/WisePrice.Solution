using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WisePriceApi.Models;
using Microsoft.EntityFrameworkCore;

namespace WisePriceApi.Controllers
{
  [Route("/api/[controller]")]
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
    public ActionResult<IEnumerable<Location>> Get(string name, int? zipcode, string address, int page, int size)
    {
      var query  = _db.Locations.Include(entry => entry.Deals).AsQueryable();

      if (name != null)
      {
        query = query.Where(entry => entry.Name.Contains(name));
      }

      if (zipcode != null)
      {
        query = query.Where(entry => entry.ZipCode == zipcode);
      }

      if (address != null)
      {
        query = query.Where(entry => entry.Address.Contains(address));
      }

      // Pagination
      int maxPageSize = 40; // max of 40 locations per page
      int pageSize = 20; //defaults to 20 locations per page

      int pageNumber = (page > 0) ? page : 1; //defaults to page 1
      if (size > 0)
      {
        pageSize = (size > maxPageSize) ? maxPageSize : size;
      }

      return query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
    }

    // GET api/locations/count
    [HttpGet("count")]
    public ActionResult<int> CountLocations(string name, int? zipcode, string address)
    {
      var query = _db.Locations.AsQueryable();

      if (name != null)
      {
        query = query.Where(entry => entry.Name.Contains(name));
      }

      if (zipcode != null)
      {
        query = query.Where(entry => entry.ZipCode == zipcode);
      }

      if (address != null)
      {
        query = query.Where(entry => entry.Address.Contains(address));
      }
      return query.ToList().Count();
    }

    [HttpGet("nearestStores")]
    public ActionResult<IEnumerable<Location>> GetNearestStore(int zipcode)
    {
      var query = _db.Locations.Include(entry => entry.Deals).Where(s => s.ZipCode == zipcode).AsQueryable();

      return query.ToList();
    }

    // GET api/locations/5
    [HttpGet("{id}")]
    public ActionResult<Location> Get(int id)
    {
      return _db.Locations.FirstOrDefault(entry => entry.LocationId == id);
    }



    // POST api/locations
    [HttpPost]
    public void Post([FromBody] Location location)
    {
      _db.Locations.Add(location);
      _db.SaveChanges();
    }

    // PUT api/locations/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Location location)
    {
      location.LocationId = id;
      _db.Entry(location).State = EntityState.Modified;
      _db.SaveChanges();
    }

    // DELETE api/locations/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var locationToDelete = _db.Locations.FirstOrDefault(entry => entry.LocationId == id);
      _db.Locations.Remove(locationToDelete);
      _db.SaveChanges();
    }
  }
}

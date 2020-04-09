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
  public class ItemsController : ControllerBase
  {
    private WisePriceApiContext _db;

    public ItemsController(WisePriceApiContext db)
    {
      _db = db;
    }

    // GET api/items
    [HttpGet]
    public ActionResult<IEnumerable<Item>> Get(string name, int page, int size)
    {
      var query = _db.Items
        .Include(entry => entry.Deals).ThenInclude(entry => entry.User)
        .Include(entry => entry.Deals).ThenInclude(entry => entry.Location).AsQueryable();

      if (name != null)
      {
          query = query.Where(entry => entry.ItemName.Contains(name));
      }
      
      // Pagination
      int maxPageSize = 40; // max of 40 items per page
      int pageSize = 20; //defaults to 20 items per page

      int pageNumber = (page > 0) ? page : 1; //defaults to page 1
      if (size > 0)
      {
        pageSize = (size > maxPageSize) ? maxPageSize : size;
      }

      return query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
    }

    // GET api/items/count
    [HttpGet("count")]
    public ActionResult<int> CountItems(string itemName)
    {
      var query = _db.Items.AsQueryable();

      if (itemName != null)
      {
        query = query.Where(entry => entry.ItemName.Contains(itemName));
      }
      return query.ToList().Count();
    }

    // GET api/items/5
    [HttpGet("{id}")]
    public ActionResult<Item> Get(int id)
    {
      return _db.Items
      .Include(entry => entry.Deals).ThenInclude(entry => entry.Location)
      .Include(entry => entry.Deals).ThenInclude(entry => entry.User).ThenInclude(entry => entry.PinnedDeals)
      .Include(entry => entry.Deals).ThenInclude(entry => entry.User).ThenInclude(entry => entry.PostedDeals)
      .FirstOrDefault(entry => entry.ItemId == id);
    }

    // POST api/items
    [HttpPost]
    public void Post([FromBody] Item item)
    {
      _db.Items.Add(item);
      _db.SaveChanges();
    }

    // PUT api/items/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Item item)
    {
      item.ItemId = id;
      _db.Entry(item).State = EntityState.Modified;
      _db.SaveChanges();
    }

    // DELETE api/items/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var itemToDelete = _db.Items.FirstOrDefault(entry => entry.ItemId == id);
      _db.Items.Remove(itemToDelete);
      _db.SaveChanges();
    }
  }
}

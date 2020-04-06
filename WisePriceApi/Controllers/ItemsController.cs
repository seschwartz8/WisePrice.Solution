using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WisePriceApi.Models;
using Microsoft.EntityFrameworkCore;
namespace WisePriceApi.Controllers
{
  [Route("/[controller]")]
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
    public ActionResult<IEnumerable<Item>> Get(string name)
    {
      var query = _db.Items.AsQueryable();

      if (name != null)
      {
          query = query.Where(entry => entry.ItemName.Contains(name));
      }

      return query.ToList();
    }

    // GET api/items/5
    [HttpGet("{id}")]
    public ActionResult<Item> Get(int id)
    {
      return _db.Items.FirstOrDefault(entry => entry.ItemId == id);
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

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
  public class ItemsController : ControllerBase
  {
    private WisePriceApiContext _db;

    public ItemsController(WisePriceApiContext db)
    {
      _db = db;
    }

    // GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<Item>> Get(string item)
    {
      var query = _db.Items.AsQueryable();

      if (item != null)
      {
          query = query.Where(entry => entry.ItemName.Contains(item));
      }

      return query.ToList();
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<string> Get(int id)
    {
      return "value";
    }

    // POST api/values
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}


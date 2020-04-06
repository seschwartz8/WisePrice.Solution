using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WisePriceApi.Models;

namespace WisePriceApi.Controllers
{
  [Route("api/[controller]")]
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
    public ActionResult<IEnumerable<string>> Get()
    {
      return new string[] { "value1", "value2" };
    }

    // GET api/items/5
    [HttpGet("{id}")]
    public ActionResult<string> Get(int id)
    {
      return "value";
    }

    // POST api/items
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/items/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/items/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}

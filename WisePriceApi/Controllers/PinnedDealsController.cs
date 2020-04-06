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
  public class PinnedDealsController : ControllerBase
  {
    private WisePriceApiContext _db;
    public PinnedDealsController(WisePriceApiContext db)
    {
      _db = db;
    }

    // GET api/pinneddeals
    [HttpGet]
    public ActionResult<IEnumerable<PinnedDeal>> Get()
    {
      var query = _db.PinnedDeals.Include(entry => entry.User).Include(entry => entry.Deal).AsQueryable();
      return query.ToList();
    }

    // GET api/pinneddeals/5
    [HttpGet("{id}")]
    public ActionResult<string> Get(int id)
    {
      return "value";
    }

    // POST api/pinneddeals
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/pinneddeals/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/pinneddeals/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}

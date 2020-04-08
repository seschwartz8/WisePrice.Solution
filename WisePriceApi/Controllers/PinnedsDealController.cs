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
  public class PinnedDealsController : ControllerBase
  {
    private WisePriceApiContext _db;

    public PinnedDealsController(WisePriceApiContext db)
    {
      _db = db;
    }

    // GET api/pinneddeals/1
    [HttpGet("{userId}")]
    public ActionResult<IEnumerable<PinnedDeal>> Get(int userId, int page, int zipcode, int size)
    {
      var query = _db.PinnedDeals
        .Include(entry => entry.User).Where(entry => entry.UserId == userId)
        .Include(entry => entry.Deal).ThenInclude(entry => entry.Item)
        .OrderByDescending(entry => entry.Deal.Item.ItemName)
        .AsQueryable();

      // Pagination
      int maxPageSize = 40; // max of 40 deals per page
      int pageSize = 20; //defaults to 20 deals per page

      int pageNumber = (page > 0) ? page : 1; //defaults to page 1
      if (size > 0)
      {
        pageSize = (size > maxPageSize) ? maxPageSize : size;
      }

      return query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
    }

    // GET api/posteddeals/1/5
    [HttpGet("{userId}/{dealId}")]
    public ActionResult<PinnedDeal> Get(int userId, int dealId)
    {
      return _db.PinnedDeals
        .Include(entry => entry.User).Where(entry => entry.UserId == userId)
        .Include(entry => entry.Deal).ThenInclude(entry => entry.Item)
        .Include(entry => entry.Deal).ThenInclude(entry => entry.Location)
        .FirstOrDefault(entry => entry.PinnedDealId == dealId);
    }

    // GET api/pinneddeals/count
    [HttpGet("count")]
    public ActionResult<int> CountPinnedDeals()
    {
      var query = _db.PinnedDeals.AsQueryable();

      return query.ToList().Count();
    }

    //POST api/pinneddeals
    [HttpPost]
    public void Post([FromBody] PinnedDeal pinnedDeal)
    {
      if (_db.PinnedDeals.Where(entry => entry.DealId == pinnedDeal.DealId).ToList().Count() == 0)
      {
        _db.PinnedDeals.Add(pinnedDeal);
      }
      _db.SaveChanges();
    }

    // DELETE api/pinneddeals/1/5
    [HttpDelete("{userId}/{dealId}")]
    public void Delete(int userId, int dealId)
    {
      var joinDealEntry = _db.PinnedDeals.Where(entry => entry.UserId == userId).FirstOrDefault(entry => entry.DealId == dealId);
      _db.PinnedDeals.Remove(joinDealEntry);
      _db.SaveChanges();
    }
  }
}

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
  public class PostedDealsController : ControllerBase
  {
    private WisePriceApiContext _db;

    public PostedDealsController(WisePriceApiContext db)
    {
      _db = db;
    }

    // GET api/posteddeals/1
    [HttpGet("{userId}")]
    public ActionResult<IEnumerable<PostedDeal>> Get(int userId, int page, int size)
    {
      var query = _db.PostedDeals
        .Include(entry => entry.User).Where(entry => entry.UserId == userId)
        .Include(entry => entry.Deal).ThenInclude(entry => entry.Item)
        .Include(entry => entry.Deal).ThenInclude(entry => entry.Location)
        .OrderByDescending(entry => entry.DealId).AsQueryable();

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
    public ActionResult<PostedDeal> Get(int userId, int dealId)
    {
      return _db.PostedDeals
        .Include(entry => entry.User).Where(entry => entry.UserId == userId)
        .Include(entry => entry.Deal).ThenInclude(entry => entry.Item)
        .Include(entry => entry.Deal).ThenInclude(entry => entry.Location)
        .FirstOrDefault(entry => entry.DealId == dealId);
    }

    // POST api/posteddeals/1
    [HttpPost("{userId}")]
    public void Post(int userId, [FromBody] PostedDeal postedDeal)
    {
      _db.PostedDeals.Add(postedDeal);
      _db.SaveChanges();
    }

    // GET api/posteddeals/1/count
    [HttpGet("{userId}/count")]
    public ActionResult<int> CountPostedDeals(int userId, string itemName, string locationName)
    {
      var query = _db.PostedDeals
        .Include(entry => entry.User).Where(entry => entry.UserId == userId)
        .Include(entry => entry.Deal).ThenInclude(entry => entry.Item)
        .Include(entry => entry.Deal).ThenInclude(entry => entry.Location)
        .OrderByDescending(entry => entry.DealId);
      return query.ToList().Count();
    }

  }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WisePriceApi.Models;

namespace WisePriceApi.Controllers
{
  [Route("/api/[controller]")]
  [ApiController]
  public class DealsController : ControllerBase
  {
    private WisePriceApiContext _db;

    public DealsController(WisePriceApiContext db)
    {
      _db = db;
    }

    // GET api/deals
    [HttpGet]
    public ActionResult<IEnumerable<Deal>> Get(string itemName, string zipCode, int page, int size)
    {
      var query = _db.Deals.Include(entry => entry.Item).Include(entry => entry.Location).Include(entry => entry.User).AsQueryable();

      if (itemName != null)
      {
        query = query.Where(entry => entry.Item.ItemName.Contains(itemName));
      }

      if (zipCode != null)
      {
        query = query.Where(entry => entry.Location.ZipCode.ToString() == zipCode);
      }

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

    // GET api/deals/count
    [HttpGet("count")]
    public ActionResult<int> CountDeals(string itemName, string locationName)
    {
      var query = _db.Deals.Include(entry => entry.Item).Include(entry => entry.Location).AsQueryable();

      if (itemName != null)
      {
        query = query.Where(entry => entry.Item.ItemName.Contains(itemName));
      }

      if (locationName != null)
      {
        query = query.Where(entry => entry.Location.Name.Contains(locationName));
      }
      return query.ToList().Count();
    }

    // GET api/deals/5
    [HttpGet("{id}")]
    public ActionResult<Deal> Get(int id)
    {
      return _db.Deals.Include(entry => entry.Item).Include(entry => entry.Location).Include(entry => entry.User).FirstOrDefault(entry => entry.DealId == id);
    }

    // POST api/deals
    [HttpPost]
    public void Post([FromBody] Deal deal)
    {
      DateTime currentTime = new DateTime();
      currentTime = DateTime.Now;
      deal.TimeUpdated = currentTime;
      _db.Deals.Add(deal);
      if (deal.UserId != null)
      {
        _db.PostedDeals.Add(new PostedDeal() { UserId = deal.UserId, DealId = deal.DealId });
      }
      _db.SaveChanges();
    }

    // PUT api/deals/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Deal deal)
    {
      deal.DealId = id;
      _db.Entry(deal).State = EntityState.Modified;
      _db.SaveChanges();
    }

    // // DELETE api/deals/1/5   WITH AUTHORIZATION
    // [HttpDelete("{userId}/{dealId}")]
    // public void Delete(string userId, int dealId)
    // {
    //   var dealToDelete = _db.Deals.FirstOrDefault(entry => entry.DealId == dealId);
    //   if (dealToDelete.UserId != null)
    //   {
    //     var postedDealToDelete = _db.PostedDeals.Where(entry => entry.UserId == userId).FirstOrDefault(entry => entry.DealId == dealId);
    //     _db.PostedDeals.Remove(postedDealToDelete);
    //     _db.SaveChanges();
    //   }
    //   _db.Deals.Remove(dealToDelete);
    //   _db.SaveChanges();
    // }

    // DELETE api/deals/5
    [HttpDelete("{dealId}")]
    public void Delete(int dealId)
    {
      var dealToDelete = _db.Deals.FirstOrDefault(entry => entry.DealId == dealId);
      _db.Deals.Remove(dealToDelete);
      _db.SaveChanges();
    }
  }
}
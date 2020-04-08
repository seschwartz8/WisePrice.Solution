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
  public class UsersController : ControllerBase
  {
    private WisePriceApiContext _db;

    public UsersController(WisePriceApiContext db)
    {
      _db = db;
    }

    // NOT USING? ================================
    // GET api/users
    // [HttpGet]
    // public ActionResult<IEnumerable<User>> Get(int page, int size)
    // {
    //   var query = _db.Users
    //     .Include(entry => entry.PinnedDeals).ThenInclude(entry => entry.Deal).ThenInclude(entry => entry.Item)
    //     //.Include(entry => entry.PinnedDeals).ThenInclude(entry => entry.Deal).ThenInclude(entry => entry.Location)
    //     // .Include(entry => entry.PinnedDeals).ThenInclude(entry => entry.Location)
    //     .Include(entry => entry.PostedDeals).AsQueryable();

    //   // Pagination
    //   int maxPageSize = 40; // max of 40 users per page
    //   int pageSize = 20; //defaults to 20 users per page

    //   int pageNumber = (page > 0) ? page : 1; //defaults to page 1
    //   if (size > 0)
    //   {
    //     pageSize = (size > maxPageSize) ? maxPageSize : size;
    //   }

    //   return query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
    // }

    // NOT USING? ================================
    // // GET api/users/count
    // [HttpGet("count")]
    // public ActionResult<int> CountUsers()
    // {
    //   var query = _db.Users.AsQueryable();
    //   return query.ToList().Count();
    // }

    // GET api/users/5
    [HttpGet("{id}")]
    public ActionResult<User> Get(int id)
    {
      var query = _db.Users
      .Include(entry => entry.PinnedDeals).ThenInclude(entry => entry.Deal)
      .Include(entry => entry.PostedDeals).ThenInclude(entry => entry.Deal)
      .FirstOrDefault(entry => entry.UserId == id);
      return query;
    }

    // POST api/users
    [HttpPost]
    public void Post([FromBody] User user)
    {
      _db.Users.Add(user);
      _db.SaveChanges();
    }

    // DELETE api/users/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var userToDelete = _db.Users.FirstOrDefault(entry => entry.UserId == id);
      _db.Users.Remove(userToDelete);
      _db.SaveChanges();
    }

    // GET api/users/5/pinneddeals
    // [HttpGet("{id}/pinneddeals")]
    // public ActionResult<User> Get(int id, int page, int size)
    // {
    //   var query = _db.Users
    //   .Include(entry => entry.PinnedDeals).ThenInclude(entry => entry.Deal)
    //   .FirstOrDefault(entry => entry.UserId == id);
    //   return query;
    // }
  }
}
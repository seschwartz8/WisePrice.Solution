// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using WisePriceApi.Models;
// using Microsoft.EntityFrameworkCore;

// namespace WisePriceApi.Controllers
// {
//   [Route("api/[controller]")]
//   [ApiController]
//   public class UsersController : ControllerBase
//   {
//     private WisePriceApiContext _db;

//     public UsersController(WisePriceApiContext db)
//     {
//       _db = db;
//     }

//     // GET api/users
//     [HttpGet]
//     public ActionResult<IEnumerable<User>> Get(string name, string username, string email, int page, int size)
//     {
//       var query = _db.Users.Include(entry => entry.PinnedDeals).AsQueryable();

//       if (name != null)
//       {
//         query = query.Where(entry => entry.FirstName.Contains(name) ||
//           entry.LastName.Contains(name));
//       }
      
//       if (username != null)
//       {
//         query = query.Where(entry => entry.UserName.Contains(username));
//       }

//       if (email != null)
//       {
//         query = query.Where(entry => entry.Email.Contains(email));
//       }

//       // Pagination
//       int maxPageSize = 40; // max of 40 users per page
//       int pageSize = 20; //defaults to 20 users per page

//       int pageNumber = (page > 0) ? page : 1; //defaults to page 1
//       if (size > 0)
//       {
//         pageSize = (size > maxPageSize) ? maxPageSize : size;
//       }

//       return query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
//     }

//     // GET api/users/count
//     [HttpGet("count")]
//     public ActionResult<int> CountUsers(string name, string username, string email)
//     {
//       var query = _db.Users.AsQueryable();

//       if (name != null)
//       {
//         query = query.Where(entry => entry.FirstName.Contains(name) ||
//           entry.LastName.Contains(name));
//       }
      
//       if (username != null)
//       {
//         query = query.Where(entry => entry.UserName.Contains(username));
//       }

//       if (email != null)
//       {
//         query = query.Where(entry => entry.Email.Contains(email));
//       }
//       return query.ToList().Count();
//     }

//     // GET api/users/5
//     [HttpGet("{id}")]
//     public ActionResult<User> Get(int id)
//     {
//       return _db.Users.FirstOrDefault(entry => entry.UserId == id);
//     }

//     // POST api/users
//     [HttpPost]
//     public void Post([FromBody] User user)
//     {
//       _db.Users.Add(user);
//       _db.SaveChanges();
//     }

//     // PUT api/users/5
//     [HttpPut("{id}")]
//     public void Put(int id, [FromBody] User user)
//     {
//       user.UserId = id;
//       _db.Entry(user).State = EntityState.Modified;
//       _db.SaveChanges();
//     }

//     // DELETE api/users/5
//     [HttpDelete("{id}")]
//     public void Delete(int id)
//     {
//       var userToDelete = _db.Users.FirstOrDefault(entry => entry.UserId == id);
//       _db.Users.Remove(userToDelete);
//       _db.SaveChanges();
//     }
//   }
// }
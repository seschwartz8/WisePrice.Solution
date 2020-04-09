using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using WisePriceClient.Models;

namespace WisePriceClient.Controllers
{
  public class PinnedDealsController : Controller
  {
    // public IActionResult Index(int id = 1)
    // {
    //   string page = $"{id}";
    //   ViewBag.Page = id;
    //   ViewBag.Size = 20;
    //   string userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    //   ViewBag.DealCount = PinnedDeal.GetCount(userId);

    //   var allPinnedDeals = PinnedDeal.GetAll(userId);
    //   return View(allPinnedDeals);
    // }

    [HttpPost]
    public IActionResult PinnedPost(string userId, int dealId)
    {
      PinnedDeal newPinnedDeal = new PinnedDeal(userId, dealId);
      PinnedDeal.Post(newPinnedDeal);
      return RedirectToAction("Index", "Deals");
    }
  }
}
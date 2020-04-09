using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WisePriceClient.Models;
using Microsoft.AspNet.Identity;

namespace WisePriceClient.Controllers
{
  public class PinnedDealsController : Controller
  {
    public IActionResult Index(int id = 1)
    {
      string page = $"{id}";
      ViewBag.Page = id;
      ViewBag.Size = 20;
      ViewBag.DealCount = PinnedDeal.GetCount(User.Identity.GetUserId());

      var allPinnedDeals = PinnedDeal.GetAll(User.Identity.GetUserId());
      return View(allPinnedDeals);
    }
  }
}

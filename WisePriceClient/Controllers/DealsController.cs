using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WisePriceClient.Models;

namespace WisePriceClient.Controllers
{
  public class DealsController : Controller
  {
    public IActionResult Index()
    {
      var allDeals = Deal.GetDeals();
      return View(allDeals);
    }

    [HttpPost]
    public IActionResult Index(Deal deal)
    {
      Deal.AddDeal(deal);
      return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
      var selectedDeal = Deal.GetDetails(id);
      return View(selectedDeal);
    }

    public IActionResult Edit(int id)
    {
      var selectedDeal = Deal.GetDetails(id);
      return View(selectedDeal);
    }

    [HttpPost]
    public IActionResult Details(int id, Deal deal)
    {
      deal.DealId = id;
      Deal.Update(deal);
      return RedirectToAction("Details", id);
    }

    public IActionResult Delete(int id)
    {
      Deal.Delete(id);
      return RedirectToAction("Index");
    }
  }
}
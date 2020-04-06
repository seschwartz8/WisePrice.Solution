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
      // var allDeals = Deal.GetAll();
      // return View(allDeals);
      return View();
    }

    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Index(Deal newDeal)
    {
      ViewBag.ItemId = Item.GetAll(); // returns a list of Item objects for dropdown of items
      Deal.Post(newDeal);
      return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
      var selectedDeal = Deal.Get(id);
      return View(selectedDeal);
    }

    [HttpPost]
    public IActionResult Details(int id, Deal dealToEdit)
    {
      dealToEdit.DealId = id;
      Deal.Put(dealToEdit);
      return RedirectToAction("Details", id);
    }

    public IActionResult Delete(int id)
    {
      Deal.Delete(id);
      return RedirectToAction("Index");
    }

    public IActionResult Pinned()
    {
      return View();
    }

    public IActionResult Posted()
    {
      return View();
    }
  }
}
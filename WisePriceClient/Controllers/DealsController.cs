using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WisePriceClient.Models;

namespace WisePriceClient.Controllers
{
  public class DealsController : Controller
  {
    public IActionResult Index()
    {
      var allDeals = Deal.GetAll();
      return View(allDeals);
    }

    public IActionResult Create()
    {
      // List<Item> allItems = Item.GetAll();
      // List<Location> allLocations = Location.GetAll();
      // ViewBag.ItemId = new SelectList(allItems, "ItemId", "ItemName");
      // ViewBag.LocationId = new SelectList(allLocations, "LocationId", "Name");
      ViewBag.allItems = Item.GetAll().OrderBy(item => item.ItemName).ToList();
      ViewBag.allLocations = Location.GetAll().OrderBy(location => location.Name).ToList();
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
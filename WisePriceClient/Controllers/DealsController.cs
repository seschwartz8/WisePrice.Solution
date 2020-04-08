using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
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
      ViewBag.allItems = Item.GetAll().OrderBy(item => item.ItemName).ToList();
      ViewBag.allLocations = Location.GetAll().OrderBy(location => location.Name).ToList();
      ViewBag.userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      return View();
    }

    [HttpPost]
    public IActionResult Create(string ItemId, string newItemName, string LocationId, string Price, string UserId)
    {
      // ItemId = int.Parse(ItemId);
      // LocationId = int.Parse(LocationId);
      // UserId = int.Parse(UserId);
      // Deal newDeal = new Deal { ItemId = ItemId, LocationId = LocationId, Price = Price, UserId = UserId };

      System.Console.WriteLine("-------------------------------------------------------------------------------------------" + newItemName + "-------------------------------------------");
      // receive new item? if so, overwrite any possible existing itemId
      // turn information into a deal

      // Deal.Post(newDeal);
      return RedirectToAction("Index");
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
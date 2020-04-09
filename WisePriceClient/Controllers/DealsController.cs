using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WisePriceClient.Models;

namespace WisePriceClient.Controllers
{
  public class DealsController : Controller
  {
    // Don't remove the "= 1", this sets the default page to 1
    public IActionResult Index(int id = 1)
    {
      string page = $"{id}";
      ViewBag.Page = id;
      ViewBag.Size = 20;
      ViewBag.DealCount = Deal.GetCount();

      var allDeals = Deal.GetAll();
      return View(allDeals);
    }

    public IActionResult Create()
    {
      ViewBag.allItems = Item.GetAll().OrderBy(item => item.ItemName).ToList();
      ViewBag.allLocations = Location.GetAll().OrderBy(location => location.Name).ToList();
      ViewBag.userId = User.Identity.GetUserId();

      return View();
    }

    [HttpPost]
    public IActionResult Create(string ItemId, string newItemName, string LocationId, string Price, string UserId)
    {
      // // Make sure user is logged in
      if (UserId != null)
      {
        // Create new item and set ItemId = to newItem's Id
        if (newItemName != null)
        {
          Item newItem = new Item(newItemName);
          Item.Post(newItem);
          List<Item> allItems = Item.GetAll();
          foreach (Item item in allItems)
          {
            if (item.ItemName == newItemName)
            {
              ItemId = item.ItemId.ToString();
            }
          }
        }

        int ItemIdInt = int.Parse(ItemId);
        int LocationIdInt = int.Parse(LocationId);

        Deal newDeal = new Deal(ItemIdInt, LocationIdInt, Price, UserId);
        Deal.Post(newDeal);
        return RedirectToAction("Index");
      }
      else
      {
        return RedirectToAction("Index");
      }
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
      ViewBag.allItems = Item.GetAll().OrderBy(item => item.ItemName).ToList();
      ViewBag.allLocations = Location.GetAll().OrderBy(location => location.Name).ToList();
      ViewBag.userId = User.Identity.GetUserId();
      var selectedDeal = Deal.Get(id);
      return View(selectedDeal);
    }

    [HttpPost]
    public IActionResult Edit(string ItemId, string newItemName, string LocationId, string Price, string UserId, int DealId)
    {
      // // Make sure user is logged in
      if (User.Identity.IsAuthenticated)
      //if (UserId != null)
      {
        // Create new item and set ItemId = to newItem's Id
        if (newItemName != null)
        {
          Item newItem = new Item(newItemName);
          Item.Post(newItem);
          List<Item> allItems = Item.GetAll();
          foreach (Item item in allItems)
          {
            if (item.ItemName == newItemName)
            {
              ItemId = item.ItemId.ToString();
            }
          }
        }

        int ItemIdInt = int.Parse(ItemId);
        int LocationIdInt = int.Parse(LocationId);

        Deal dealToEdit = new Deal(DealId, ItemIdInt, LocationIdInt, Price, UserId);
        Deal.Put(dealToEdit);
        return RedirectToAction("Posted");
      }
      else
      {
        return RedirectToAction("Posted");
      }
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

    public IActionResult Pinned(string userId, int dealId, Deal DealtoPinned)
    {
      PinnedDeal.Post(DealtoPinned);
      return View();
    }

    // Don't remove the "= 1", this sets the default page to 1
    public IActionResult Posted(int id = 1)
    {
      string page = $"{id}";
      ViewBag.Page = id;
      ViewBag.Size = 20;
      string userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      ViewBag.DealCount = PostedDeal.GetCount(userId);

      var allPostedDeals = PostedDeal.GetAll(userId);
      return View(allPostedDeals);
    }
  }
}
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WisePriceClient.Models
{
  public class Deal
  {
    public int DealId { get; set; }
    public int ItemId { get; set; }
    public int LocationId { get; set; }
    public string UserId { get; set; }
    public string Price { get; set; }
    public DateTime TimeUpdated { get; set; }
    public int UpVotes { get; set; }
    public int DownVotes { get; set; }
    public virtual Item Item { get; set; }
    public virtual Location Location { get; set; }

    public Deal(int itemId, int locationId, string price, string userId)
    {
      ItemId = itemId;
      LocationId = locationId;
      Price = price;
      UserId = userId;
    }

    public static List<Deal> GetAll()
    {
      var apiCallTask = ApiHelper.GetAllDeals();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Deal> dealList = JsonConvert.DeserializeObject<List<Deal>>(jsonResponse.ToString());

      return dealList;
    }

    // Gets Count of all deals
    public static int GetCount()
    {
      var apiCallTask = ApiHelper.GetDealCount();
      var result = int.Parse(apiCallTask.Result);
      return result;
    }

    public static Deal Get(int id)
    {
      var apiCallTask = ApiHelper.GetDeal(id);
      var result = apiCallTask.Result;
      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Deal deal = JsonConvert.DeserializeObject<Deal>(jsonResponse.ToString());
      return deal;
    }

    public static void Post(Deal newDeal)
    {
      string jsonReview = JsonConvert.SerializeObject(newDeal);
      var apiCallTask = ApiHelper.PostDeal(jsonReview);
    }

    public static void Put(Deal dealToEdit)
    {
      string jsonReview = JsonConvert.SerializeObject(dealToEdit);
      var apiCallTask = ApiHelper.PutDeal(dealToEdit.DealId, jsonReview);
    }

    public static void Delete(int id)
    {
      var apiCallTask = ApiHelper.DeleteDeal(id);
    }
  }
}
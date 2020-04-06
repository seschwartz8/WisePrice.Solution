using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WisePriceClient.Models
{
  public class Deal
  {
    public int DealId { get; set; }
    public int ItemId { get; set; }
    public int LocationId { get; set; }
    public int UserId { get; set; }
    public int Price { get; set; }
    public DateTime TimeUpdated { get; set; }
    public int UpVotes { get; set; }
    public int DownVotes { get; set; }
    public virtual Item Item {get; set;}
    public virtual Location Location {get; set;}
    
    public static List<Deal> GetAll()
    {
      var apiCallTask = ApiHelper.GetAllDeals();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Deal> dealList = JsonConvert.DeserializeObject<List<Deal>>(jsonResponse.ToString());

      return dealList;
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
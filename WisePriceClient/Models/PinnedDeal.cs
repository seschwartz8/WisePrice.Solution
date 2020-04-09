using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WisePriceClient.Models
{
  public class PinnedDeal
  {
    public int PinnedDealId { get; set; }
    public string UserId { get; set; }
    public int DealId { get; set; }

    // public virtual ApplicationUser User { get; set; }
    public virtual User User {get; set;}
    public virtual Deal Deal { get; set; }

    public static List<PinnedDeal> GetAll(string userId)
    {
      var apiCallTask = ApiHelper.GetAllPinnedDeals(userId);
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<PinnedDeal> pinnedDealList = JsonConvert.DeserializeObject<List<PinnedDeal>>(jsonResponse.ToString());

      return pinnedDealList;
    }

    public static PinnedDeal Get(string userId, int dealId)
    {
      var apiCallTask = ApiHelper.GetPinnedDeal(userId, dealId);
      var result = apiCallTask.Result;
      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      PinnedDeal pinnedDeal = JsonConvert.DeserializeObject<PinnedDeal>(jsonResponse.ToString());
      return pinnedDeal;
    }

    public static void Post(PinnedDeal newPinnedDeal)
    {
      string jsonPinnedDeal = JsonConvert.SerializeObject(newPinnedDeal);
      var apiCallTask = ApiHelper.PostPinnedDeal(jsonPinnedDeal);
    }

    public static void Delete(string userId, int dealId)
    {
      var apiCallTask = ApiHelper.DeletePinnedDeal(userId, dealId);
    }

    public static int GetCount(string userId)
    {
      var apiCallTask = ApiHelper.GetPinnedDealCount(userId);
      var result = int.Parse(apiCallTask.Result);
      return result;
    }
  }
}
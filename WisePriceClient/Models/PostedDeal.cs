using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WisePriceClient.Models
{
  public class PostedDeal
  {
    public int PostedDealId { get; set; }
    public string UserId { get; set; }
    public int DealId { get; set; }

    public virtual ApplicationUser User { get; set; }
    public virtual Deal Deal { get; set; }

    // See DEALS for DELETE POSTED DEAL ACTION
    public static List<PostedDeal> GetAll(string userId)
    {
      var apiCallTask = ApiHelper.GetAllPostedDeals(userId);
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<PostedDeal> postedDealList = JsonConvert.DeserializeObject<List<PostedDeal>>(jsonResponse.ToString());

      return postedDealList;
    }

    public static PinnedDeal Get(string userId, int dealId)
    {
      var apiCallTask = ApiHelper.GetPinnedDeal(userId, dealId);
      var result = apiCallTask.Result;
      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      PinnedDeal pinnedDeal = JsonConvert.DeserializeObject<PinnedDeal>(jsonResponse.ToString());
      return pinnedDeal;
    }

    public static void Post(string userId, PostedDeal newPostedDeal)
    {
      string jsonPostedDeal = JsonConvert.SerializeObject(newPostedDeal);
      var apiCallTask = ApiHelper.PostPostedDeal(userId, jsonPostedDeal);
    }

    public static int GetCount(string userId)
    {
      var apiCallTask = ApiHelper.GetPostedDealCount(userId);
      var result = int.Parse(apiCallTask.Result);
      return result;
    }
  }
}
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WisePriceClient.Models
{
  public class APIUser
  {
    public string UserId { get; set; }
    public virtual ICollection<PinnedDeal> PinnedDeals { get; set; }
    public virtual ICollection<PostedDeal> PostedDeals { get; set; }

    public static void Post(APIUser newUser)
    {
      string jsonNewUser = JsonConvert.SerializeObject(newUser);
      var apiCallTask = ApiHelper.PostUser(jsonNewUser);
    }

    public static APIUser Get(string userId)
    {
      var apiCallTask = ApiHelper.GetUser(userId);
      var result = apiCallTask.Result;
      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      APIUser user = JsonConvert.DeserializeObject<APIUser>(jsonResponse.ToString());
      return user;
    }
  }
}
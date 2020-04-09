using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WisePriceClient.Models
{
  public class APIUser
  {
    public string UserId { get; set; }
    public virtual ICollection<PinnedDeal> PinnedDeals {get; set;}
    public virtual ICollection<PostedDeal> PostedDeals {get; set;}

    public static void Post(APIUser newUser)
    {
      string jsonNewUser = JsonConvert.SerializeObject(newUser);
      var apiCallTask = ApiHelper.PostUser(jsonNewUser);
    }
  }
}
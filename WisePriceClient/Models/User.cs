using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WisePriceClient.Models
{
  public class User
  {
    public string UserId { get; set; }
    public virtual ICollection<PinnedDeal> PinnedDeals {get; set;}
    public virtual ICollection<PostedDeal> PostedDeals {get; set;}
  }
}
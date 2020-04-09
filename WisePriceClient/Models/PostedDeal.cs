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
  }
}
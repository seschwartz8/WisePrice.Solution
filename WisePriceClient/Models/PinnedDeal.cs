using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WisePriceClient.Models
{
  public class PinnedDeal
  {
    public int PinnedDealId { get; set; }
    public int UserId { get; set; }
    public int DealId { get; set; }

    public virtual User User {get; set;}
    public virtual Deal Deal {get; set;}
  }
}
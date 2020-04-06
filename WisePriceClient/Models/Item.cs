using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WisePriceClient.Models
{
  public class Item
  {
    public string ItemName {get; set;}
    public int ItemId {get; set;}
    public virtual ICollection<Deal> Deals {get; set;}

    public Item()
    {
      this.Deals = new HashSet<Deal>();
    }
  }
}
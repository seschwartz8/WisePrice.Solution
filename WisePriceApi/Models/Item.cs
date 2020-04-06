using System;
using System.Collections.Generic;


namespace WisePriceApi.Models
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


using System;
using System.Collections.Generic;

namespace WisePriceApi.Models
{
  public class Location
  {
    public int LocationId { get; set; }
    public string Name { get; set; }
    public int ZipCode { get; set; }
    public string Address { get; set; }
    public virtual ICollection<Deal> Deals {get; set;}

    public Location()
    {
      this.Deals = new HashSet<Deal>();
    }
  }
}
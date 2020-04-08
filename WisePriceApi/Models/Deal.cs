using System;

namespace WisePriceApi.Models
{
  public class Deal
  {
    public int DealId { get; set; }
    public int ItemId { get; set; }
    public int LocationId { get; set; }
    public string UserId { get; set; }
    public string Price { get; set; }
    public DateTime TimeUpdated { get; set; }
    public int UpVotes { get; set; }
    public int DownVotes { get; set; }
    public virtual Item Item {get; set;}
    public virtual Location Location {get; set;}
    public virtual User User {get; set;}
  }
}
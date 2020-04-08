using Newtonsoft.Json;

namespace WisePriceApi.Models
{
  public class PinnedDeal
  {
    public int PinnedDealId { get; set; }
    public string UserId { get; set; }
    public int DealId { get; set; }

    public virtual User User {get; set;}
    public virtual Deal Deal {get; set;}
  }
}
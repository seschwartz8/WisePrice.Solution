// using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WisePriceApi.Models
{
  public class User
  {
    public int UserId { get; set; }
    public virtual ICollection<PinnedDeal> PinnedDeals {get; set;}
    public virtual ICollection<PostedDeal> PostedDeals {get; set;}

    public User()
    {
      this.PinnedDeals = new HashSet<PinnedDeal>();
      this.PostedDeals = new HashSet<PostedDeal>();
    }
  }
}
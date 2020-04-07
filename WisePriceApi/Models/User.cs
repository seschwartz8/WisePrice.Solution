using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WisePriceApi.Models
{
  public class User : IdentityUser
  {
    public int UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }

    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    public string Zip { get; set; }
    public int Password {get; set;}
    // [InverseProperty(nameof(PinnedDeal.User))]
    public virtual ICollection<PinnedDeal> PinnedDeals {get; set;}
    //[InverseProperty(nameof(Deal.Poster))] 
    public virtual ICollection<Deal> PostedDeals {get; set;}

    public User()
    {
      this.PinnedDeals = new HashSet<PinnedDeal>();
      this.PostedDeals = new HashSet<Deal>();
    }
  }
}
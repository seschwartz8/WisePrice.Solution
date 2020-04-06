using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

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
    public virtual ICollection<Deal> PinnedDeals {get; set;}
    public virtual ICollection<Deal> PostedDeals {get; set;}

    public User()
    {
      this.PinnedDeals = new HashSet<Deal>();
      this.PostedDeals = new HashSet<Deal>();
    }
      
  }
}
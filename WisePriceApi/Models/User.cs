using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

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
      
  }
}
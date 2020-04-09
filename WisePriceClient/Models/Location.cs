using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WisePriceClient.Models
{
  public class Location
  {
    public int LocationId { get; set; }
    public string Name { get; set; }
    public int ZipCode { get; set; }
    public string Address { get; set; }
    public virtual ICollection<Deal> Deals {get; set;}

    public static List<Location> GetAll()
    {
      var apiCallTask = ApiHelper.GetAllLocations();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Location> locationList = JsonConvert.DeserializeObject<List<Location>>(jsonResponse.ToString());

      return locationList;
    }

    public static Location Get(int id)
    {
      var apiCallTask = ApiHelper.GetLocation(id);
      var result = apiCallTask.Result;
      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Location location = JsonConvert.DeserializeObject<Location>(jsonResponse.ToString());
      return location;
    }

    public static void Post(Location newLocation)
    {
      string jsonReview = JsonConvert.SerializeObject(newLocation);
      var apiCallTask = ApiHelper.PostLocation(jsonReview);
    }

    public static void Put(Location locationToEdit)
    {
      string jsonReview = JsonConvert.SerializeObject(locationToEdit);
      var apiCallTask = ApiHelper.PutLocation(locationToEdit.LocationId, jsonReview);
    }

    public static void Delete(int id)
    {
      var apiCallTask = ApiHelper.DeleteLocation(id);
    }
  }
}
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

    public static List<Item> GetAll()
    {
      var apiCallTask = ApiHelper.GetAllItems();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Item> itemList = JsonConvert.DeserializeObject<List<Item>>(jsonResponse.ToString());

      return itemList;
    }

    public static Item Get(int id)
    {
      var apiCallTask = ApiHelper.GetItem(id);
      var result = apiCallTask.Result;
      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Item item = JsonConvert.DeserializeObject<Item>(jsonResponse.ToString());
      return item;
    }

    public static void Post(Item newItem)
    {
      string jsonReview = JsonConvert.SerializeObject(newItem);
      var apiCallTask = ApiHelper.PostItem(jsonReview);
    }

    public static void Put(Item itemToEdit)
    {
      string jsonReview = JsonConvert.SerializeObject(itemToEdit);
      var apiCallTask = ApiHelper.PutItem(itemToEdit.ItemId, jsonReview);
    }

    public static void Delete(int id)
    {
      var apiCallTask = ApiHelper.DeleteItem(id);
    }
  }
}
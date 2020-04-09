using System.Threading.Tasks;
using RestSharp;

namespace WisePriceClient.Models
{
  class ApiHelper
  {
    // DEALS =====================================
    public static async Task<string> GetAllDeals()
    {
      RestClient client = new RestClient("http://localhost:5003/api");
      RestRequest request = new RestRequest("deals", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> GetDealCount()
    {
      RestClient client = new RestClient("http://localhost:5003/api");
      RestRequest request = new RestRequest($"deals/count", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> GetDeal(int id)
    {
      RestClient client = new RestClient("http://localhost:5003/api");
      RestRequest request = new RestRequest($"deals/{id}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task PostDeal(string newDeal)
    {
      RestClient client = new RestClient("http://localhost:5003/api");
      RestRequest request = new RestRequest($"deals", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newDeal);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task PutDeal(int id, string dealToEdit)
    {
      RestClient client = new RestClient("http://localhost:5003/api");
      RestRequest request = new RestRequest($"deals/{id}", Method.PUT);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(dealToEdit);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task DeleteDeal(int id)
    {
      RestClient client = new RestClient("http://localhost:5003/api");
      RestRequest request = new RestRequest($"deals/{id}", Method.DELETE);
      request.AddHeader("Content-Type", "application/json");
      var response = await client.ExecuteTaskAsync(request);
    }

    // ITEMS =======================================
    public static async Task<string> GetAllItems()
    {
      RestClient client = new RestClient("http://localhost:5003/api");
      RestRequest request = new RestRequest($"items", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> GetItem(int id)
    {
      RestClient client = new RestClient("http://localhost:5003/api");
      RestRequest request = new RestRequest($"items/{id}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task PostItem(string newItem)
    {
      RestClient client = new RestClient("http://localhost:5003/api");
      RestRequest request = new RestRequest($"items", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newItem);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task PutItem(int id, string itemToEdit)
    {
      RestClient client = new RestClient("http://localhost:5003/api");
      RestRequest request = new RestRequest($"items/{id}", Method.PUT);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(itemToEdit);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task DeleteItem(int id)
    {
      RestClient client = new RestClient("http://localhost:5003/api");
      RestRequest request = new RestRequest($"items/{id}", Method.DELETE);
      request.AddHeader("Content-Type", "application/json");
      var response = await client.ExecuteTaskAsync(request);
    }

    // LOCATIONS ============================================
    public static async Task<string> GetAllLocations()
    {
      RestClient client = new RestClient("http://localhost:5003/api");
      RestRequest request = new RestRequest($"locations", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> GetLocation(int id)
    {
      RestClient client = new RestClient("http://localhost:5003/api");
      RestRequest request = new RestRequest($"locations/{id}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task PostLocation(string newLocation)
    {
      RestClient client = new RestClient("http://localhost:5003/api");
      RestRequest request = new RestRequest($"locations", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newLocation);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task PutLocation(int id, string locationToEdit)
    {
      RestClient client = new RestClient("http://localhost:5003/api");
      RestRequest request = new RestRequest($"locations/{id}", Method.PUT);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(locationToEdit);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task DeleteLocation(int id)
    {
      RestClient client = new RestClient("http://localhost:5003/api");
      RestRequest request = new RestRequest($"locations/{id}", Method.DELETE);
      request.AddHeader("Content-Type", "application/json");
      var response = await client.ExecuteTaskAsync(request);
    }

    // PINNED DEALS =========================================
    public static async Task<string> GetAllPinnedDeals(string userId)
    {
      RestClient client = new RestClient("http://localhost:5003/api");
      RestRequest request = new RestRequest($"pinneddeals/{userId}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> GetPinnedDeal(string userId, int dealId)
    {
      RestClient client = new RestClient("http://localhost:5003/api");
      RestRequest request = new RestRequest($"pinneddeals/{userId}/{dealId}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task DeletePinnedDeal(string userId, int dealId)
    {
      RestClient client = new RestClient("http://localhost:5003/api");
      RestRequest request = new RestRequest($"pinneddeals/{userId}/{dealId}", Method.DELETE);
      request.AddHeader("Content-Type", "application/json");
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task<string> GetPinnedDealCount(string userId)
    {
      RestClient client = new RestClient("http://localhost:5003/api");
      RestRequest request = new RestRequest($"pinneddeals/{userId}/count", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task PostPinnedDeal(string newPinnedDeal)
    {
      RestClient client = new RestClient("http://localhost:5003/api");
      RestRequest request = new RestRequest($"pinneddeals", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newPinnedDeal);
      var response = await client.ExecuteTaskAsync(request);
    }

    // POSTED DEALS ================================
    // See DEALS for DELETE POSTED DEAL ACTION
    public static async Task<string> GetAllPostedDeals(string userId)
    {
      RestClient client = new RestClient("http://localhost:5003/api");
      RestRequest request = new RestRequest($"posteddeals/{userId}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> GetPostedDeal(string userId, int dealId)
    {
      RestClient client = new RestClient("http://localhost:5003/api");
      RestRequest request = new RestRequest($"posteddeals/{userId}/{dealId}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task PostPostedDeal(string userId, string newPostedDeal)
    {
      RestClient client = new RestClient("http://localhost:5003/api");
      RestRequest request = new RestRequest($"posteddeals/{userId}", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newPostedDeal);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task<string> GetPostedDealCount(string userId)
    {
      RestClient client = new RestClient("http://localhost:5003/api");
      RestRequest request = new RestRequest($"posteddeals/{userId}/count", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    // USERS =================================
    public static async Task PostUser(string newUser)
    {
      RestClient client = new RestClient("http://localhost:5003/api");
      RestRequest request = new RestRequest($"users", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newUser);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task DeleteUser(string userId)
    {
      RestClient client = new RestClient("http://localhost:5003/api");
      RestRequest request = new RestRequest($"users/{userId}", Method.DELETE);
      request.AddHeader("Content-Type", "application/json");
      var response = await client.ExecuteTaskAsync(request);
    }
    
    public static async Task<string> GetUser(string userId)
    {
      RestClient client = new RestClient("http://localhost:5003/api");
      RestRequest request = new RestRequest($"users/{userId}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
  }
}
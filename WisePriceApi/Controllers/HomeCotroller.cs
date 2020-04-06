using Microsoft.AspNetCore.Mvc;

namespace WisePriceApi.Controllers
{
  public class HomeController : Controller
  {

    public ActionResult Index()
    {
      return View();
    }

  }
}
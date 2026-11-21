using Microsoft.AspNetCore.Mvc;
namespace MVC_01.Controllers
{
    public class ProductController : Controller
    {
        [HttpGet]
        public string TestAction ()
        {
            return "Hello";

        }
    }
}

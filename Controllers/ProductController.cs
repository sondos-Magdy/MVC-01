using Microsoft.AspNetCore.Mvc;
using MVC_01.Models;
using System.Net.Mime;
using System.Reflection.Metadata.Ecma335;
namespace MVC_01.Controllers
{
    [Route("test")]
    public class ProductController : Controller
    {
        [HttpGet]
        public IActionResult GetById([FromQuery] int id ,  [FromQuery (Name= "id2")]int otherid)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Search(ProductFilter filter )
        {
            return View();
        }









        [HttpGet("json")]
        public IActionResult JsonAction()
        {
            return Json("Hello From Json Action");
        }

        [HttpGet("ProductCode/{code:int}")]
        public IActionResult GetProductByCode (int code)
        {
            return Json(new Product() { Id = code, Name = " Laptop" });
        }










        private int id;

        [HttpGet]
        public ViewResult Index()
        {
            return View();

        }
        [HttpGet]
        public JsonResult GetProduct()
        {
            var products = new List<Product>()
            {new Product { Id = 10, Name = "Laptop" },

            new Product { Id = 20, Name = "Mobile" } };

            return Json(products);
        }
        public IActionResult  GetProductById( int id)
        {
            if (id < 0)
                return BadRequest();
            else if (id == 0)
                return RedirectToAction(nameof(Index));
            else if (id < 10)
                return NotFound();
            else
                return Json(new Product() { Id = id, Name = "Laptop" });
        }
        [HttpGet]
         public IActionResult RedirectToLink()
        {
            return Redirect("https://drive.google.com/drive/folders/1TKHT7qNB6qqyuLnAOZ60GwuoPc52Rr7B"); 
        }

        public IActionResult FileAction()
        {
            var fileBytes = System.IO.File.ReadAllBytes("wwwroot/Files/project Computer Architecture pase 2.pdf");
            return File(fileBytes, "application/pdf", "Testfile.pdf");
        }



    }
}

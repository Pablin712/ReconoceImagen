using Microsoft.AspNetCore.Mvc;
using ReconoceImagen;
using ReconoceImagenWeb.Models;
using System.Diagnostics;
namespace ReconoceImagenWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ConsumeACV _acv = new();

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string imageUrl)
        {
            try
            {
                var result = await _acv.AnalyzeImage(imageUrl);

                ViewBag.ImageUrl = imageUrl;
                ViewBag.Caption = result.captionResult?.values?.FirstOrDefault()?.text;
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }

            return View();
        }
    }
}

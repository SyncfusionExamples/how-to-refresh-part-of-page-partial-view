using Microsoft.AspNetCore.Mvc;
using PageRefresh.Models;
using System.Diagnostics;

namespace PageRefresh.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            var data = GetPivotData();
            ViewBag.DataSource = data;
            return View();
        }

        public ActionResult PartialView()
        {
            return PartialView("PartialView");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public List<PivotData> GetPivotData()
        {
            List<PivotData> pivotData = new List<PivotData>();
            pivotData.Add(new PivotData { Sold = 31, Amount = 52824, Country = "France", Products = "Mountain Bikes", Year = "FY 2015", Quarter = "Q1" });
            pivotData.Add(new PivotData { Sold = 51, Amount = 86904, Country = "France", Products = "Mountain Bikes", Year = "FY 2015", Quarter = "Q2" });
            pivotData.Add(new PivotData { Sold = 90, Amount = 153360, Country = "France", Products = "Mountain Bikes", Year = "FY 2015", Quarter = "Q3" });
            pivotData.Add(new PivotData { Sold = 25, Amount = 42600, Country = "France", Products = "Mountain Bikes", Year = "FY 2015", Quarter = "Q4" });
            pivotData.Add(new PivotData { Sold = 27, Amount = 46008, Country = "France", Products = "Mountain Bikes", Year = "FY 2016", Quarter = "Q1" });
            return pivotData;
        }

        public List<PivotData> GetPivotData2()
        {
            List<PivotData> pivotData = new List<PivotData>();
            pivotData.Add(new PivotData { Sold = 31, Amount = 52824, Country = "Germany", Products = "Mountain Bikes", Year = "FY 2015", Quarter = "Q1" });
            pivotData.Add(new PivotData { Sold = 51, Amount = 86904, Country = "Germany", Products = "Mountain Bikes", Year = "FY 2015", Quarter = "Q2" });
            pivotData.Add(new PivotData { Sold = 90, Amount = 153360, Country = "Germany", Products = "Mountain Bikes", Year = "FY 2015", Quarter = "Q3" });
            pivotData.Add(new PivotData { Sold = 25, Amount = 42600, Country = "Germany", Products = "Mountain Bikes", Year = "FY 2015", Quarter = "Q4" });
            pivotData.Add(new PivotData { Sold = 27, Amount = 46008, Country = "Germany", Products = "Mountain Bikes", Year = "FY 2016", Quarter = "Q1" });
            return pivotData;
        }

        public class PivotData
        {
            public int Sold { get; set; }
            public double Amount { get; set; }
            public string Country { get; set; }
            public string Products { get; set; }
            public string Year { get; set; }
            public string Quarter { get; set; }
        }

        [HttpPost]
        public JsonResult PassIntFromView()
        {

            var data = GetPivotData2();
            return Json(data);
        }
    }
}
using FrontEndApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace FrontEndApp.Controllers
{
    public class LearningController : Controller
    {
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();

            var url = "https://localhost:7044/api/Testing/SaveData?name='anbc'&desc='fefw'";
            HttpResponseMessage response = client.PostAsync(url,null).Result;
            var result = response.Content.ReadAsStringAsync().Result;

            return View();
        }
    }
}

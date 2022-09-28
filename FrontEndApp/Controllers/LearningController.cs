using FrontEndApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Text;

namespace FrontEndApp.Controllers
{
    public class LearningController : Controller
    {
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();

            var url = "https://localhost:7044/api/Testing/FetchData";
            HttpResponseMessage response = client.GetAsync(url).Result;
            var result = response.Content.ReadAsStringAsync().Result;
            var dataTable = JsonConvert.DeserializeObject<DataTable>(result);
            List<Message> messages = new List<Message>();
            if(dataTable != null)
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    DataRow dr = dataTable.Rows[i];
                    Message message = new Message 
                    { 
                        id = int.Parse(dr[0].ToString()),
                        name = dr[1].ToString(),
                        desc = dr[2].ToString()
                    };
                    messages.Add(message);
                }
            return View(messages);
        }

        public IActionResult SaveData()
        {
            HttpClient client = new HttpClient();

            var url = "https://localhost:7044/api/Testing/SaveData?name='anbc'&desc='fefw'";
            HttpResponseMessage response = client.PostAsync(url,null).Result;
            var result = response.Content.ReadAsStringAsync().Result;

            return View();
        }
    }
}

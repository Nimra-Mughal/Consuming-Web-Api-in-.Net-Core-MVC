using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using WebApplication11.Models;

namespace WebApplication11.Controllers
{
    public class HomeController : Controller
    {
        private string url = "https://localhost:7020/api/Student/";
        HttpClient client = new HttpClient();
        public IActionResult Index()
        {
            List<Student> std = new List<Student>();
            HttpResponseMessage response = client.GetAsync(url).Result;
            string result= response.Content.ReadAsStringAsync().Result;
            var data = JsonConvert.DeserializeObject<List<Student>>(result);
            if(data != null)
            {
                std = data;
            }
            return View(std);
        }
        
        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student std)
        {
            var data = JsonConvert.SerializeObject(std);
            StringContent content = new StringContent(data,Encoding.UTF8,"application/json");
            HttpResponseMessage response = client.PostAsync(url, content).Result;
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Details(int id)
        {
            Student std = new Student();
            HttpResponseMessage response = client.GetAsync(url+id).Result;
            string result=response.Content.ReadAsStringAsync().Result;
            var data=JsonConvert.DeserializeObject<Student>(result);
            if(data != null)
            {
                std = data;
            }
            return View(std);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Student std = new Student();
            HttpResponseMessage response = client.GetAsync(url + id).Result;
            string result = response.Content.ReadAsStringAsync().Result;
            var data = JsonConvert.DeserializeObject<Student>(result);
            if (data != null)
            {
                std = data;
            }
            return View(std);
        }
        [HttpPost]
        public IActionResult Edit(Student std)
        {
            var data=JsonConvert.SerializeObject(std);
            StringContent content = new StringContent(data,Encoding.UTF8,"application/json");
            HttpResponseMessage response = client.PutAsync(url + std.Id, content).Result;
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Student std = new Student();
            HttpResponseMessage response = client.GetAsync(url + id).Result;
            string result = response.Content.ReadAsStringAsync().Result;
            var data = JsonConvert.DeserializeObject<Student>(result);
            if (data != null)
            {
                std = data;
            }
            return View(std);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult Deletee(int id)
        {
            HttpResponseMessage response = client.DeleteAsync(url + id).Result;
            return RedirectToAction("Index");

        }






















        //[HttpGet]
        //public IActionResult Create()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Create(Student std)
        //{
        //    var data = JsonConvert.SerializeObject(std);
        //    StringContent content = new StringContent(data,Encoding.UTF8,"application/json");
        //    HttpResponseMessage response = client.PostAsync(url, content).Result;
        //    if (response.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}
        //[HttpGet]
        //public IActionResult Edit(int id)
        //{
        //    Student std = new Student();
        //    HttpResponseMessage response = client.GetAsync(url + id).Result;
        //    if (response.IsSuccessStatusCode)
        //    {
        //        string result = response.Content.ReadAsStringAsync().Result;
        //        var data = JsonConvert.DeserializeObject<Student>(result);
        //        if (data != null)
        //        {
        //            std = data;
        //        }
        //    }
        //    return View(std);
        //}
        //[HttpPost]
        //public IActionResult Edit(Student std)
        //{
        //    var data = JsonConvert.SerializeObject(std);
        //    StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
        //    HttpResponseMessage response = client.PutAsync(url + std.Id, content).Result;
        //    if (response.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}
        //[HttpGet]
        //public IActionResult Delete(int id)
        //{
        //    Student std = new Student();
        //    HttpResponseMessage response = client.GetAsync(url + id).Result;
        //    if (response.IsSuccessStatusCode)
        //    {
        //        string result = response.Content.ReadAsStringAsync().Result;
        //        var data = JsonConvert.DeserializeObject<Student>(result);
        //        if (data != null)
        //        {
        //            std = data;
        //        }
        //    }
        //    return View(std);
        //}
        //[HttpPost, ActionName("Delete")]
        //public IActionResult DeleteConfirmed(int id)
        //{
        //    HttpResponseMessage response = client.DeleteAsync(url + id).Result;
        //    if (response.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}
    }
    }

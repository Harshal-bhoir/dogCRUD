using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FirstApp.Models;
using System.Text.Json;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FirstApp.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: /<controller>/
        private static List<DogViewModel> dogs = new List<DogViewModel>();
        private string jsonPath = "/Users/harshalb/Projects/JsonFiles/csvjson.json";

        public IActionResult Index()
        {
            return View(dogs);
        }

        public IActionResult Create()
        {
            var dogVm = new DogViewModel();
            return View(dogVm);
        }

        public IActionResult CreateDog(DogViewModel dogViewModel)
        {
            string existString = System.IO.File.ReadAllText(@jsonPath);
            if(existString.Length > 0)
            {
                var existText = JsonSerializer.Deserialize<List<DogViewModel>>(existString);
                foreach(var txt in existText)
                {
                    dogs.Add(txt);
                }
            }
       
            dogs.Add(dogViewModel);

            var jsonData = JsonSerializer.Serialize(dogs);
            System.IO.File.WriteAllText(jsonPath, jsonData);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult ViewDog()
        {
            string existString = System.IO.File.ReadAllText(@jsonPath);
            ViewBag.Message = existString;
            return View();
        }

        public IActionResult Delete()
        {
            var dogVm = new DogViewModel();
            return View(dogVm);
        }

        public IActionResult DeleteDog(DogViewModel dogId)
        {
            dogs = new List<DogViewModel>();
            string existString = System.IO.File.ReadAllText(@jsonPath);
            if(existString.Length < 1)
            {
                return View();
            }

            var existText = JsonSerializer.Deserialize<List<DogViewModel>>(existString);
            foreach (var txt in existText)
            {
                if(txt.Id != dogId.Id)
                {
                    dogs.Add(txt);
                }
            }

            var jsonData = JsonSerializer.Serialize(dogs);
            System.IO.File.WriteAllText(jsonPath, jsonData);

            return RedirectToAction(nameof(ViewDog));
        }

        public string Hello()
        {
            return "Hello From HelloWorld controller";
        }
    }
}


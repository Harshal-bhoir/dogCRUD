using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FirstApp.Models;
using System.Text.Json;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace FirstApp.Controllers
{
    public class HelloWorldController : Controller
    {
        CrudOps ob = new CrudOps();
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewDog()
        {
            List<DogViewModel> list = ob.get();
            return View(list);
        }

        public IActionResult Create()
        {
            var dogVm = new DogViewModel();
            return View(dogVm);
        }

        public IActionResult CreateDog(DogViewModel dogViewModel)
        {
            ob.post(dogViewModel);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update()
        {
            var dogVm = new DogViewModel();
            return View(dogVm);
        }

        public IActionResult UpdateDog(DogViewModel dog)
        {
            ob.put(dog);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete()
        {
            var dogVm = new DogViewModel();
            return View(dogVm);
        }

        public IActionResult DeleteDog(DogViewModel dog)
        {
            ob.delete(dog.Id);

            return RedirectToAction(nameof(ViewDog));
        }

        public string Hello()
        {
            return "Hello From HelloWorld controller";
        }
    }
}


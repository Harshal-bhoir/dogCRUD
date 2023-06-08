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
        CrudOperations ob = new CrudOperations();
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewDog()
        {
            List<DogViewModel> list = ob.get<DogViewModel>();
            return View(list);
        }

        public IActionResult Create()
        {
            var dogVm = new DogViewModel();
            return View(dogVm);
        }

        public IActionResult CreateDog(DogViewModel dogViewModel)
        {
            ob.post<DogViewModel>(dogViewModel);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update()
        {
            var dogVm = new DogViewModel();
            return View(dogVm);
        }

        public IActionResult UpdateDog(DogViewModel dog)
        {
            ob.put<DogViewModel>(dog);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete()
        {
            var dogVm = new DogViewModel();
            return View(dogVm);
        }

        public IActionResult DeleteDog(DogViewModel dogId)
        {
            ob.delete<DogViewModel>(dogId);

            return RedirectToAction(nameof(ViewDog));
        }

        public string Hello()
        {
            return "Hello From HelloWorld controller";
        }
    }
}


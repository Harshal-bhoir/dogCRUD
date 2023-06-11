using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using FirstApp.Models;

namespace FirstApp.Controllers
{
    [Route("api/[controller]")]
    public class HelloWorldAPIController
	{
        CrudOps ob = new CrudOps();

        // GET: api/DogViewModels
        [HttpGet]
        public List<DogViewModel> Get()
        {
            var existText = ob.get();
            return existText;
        }

        // GET: api/DogViewModels/5
        [HttpGet("{id}", Name = "Get")]
        public DogViewModel Get(int id)
        {
            var getDog = ob.get(id);

            return getDog;
        }

        [HttpPost]
        public void Post([FromBody] DogViewModel value)
        {
            ob.post(value);
        }

        [HttpPut("{id}")]
        public void Put([FromBody] DogViewModel value)
        {
            ob.put(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ob.delete(id);
        }
    }
}


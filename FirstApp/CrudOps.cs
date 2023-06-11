using System;
using FirstApp.Models;
using System.Text.Json;


namespace FirstApp
{
    public class CrudOps
    {
        HelperFuncs ob = new HelperFuncs();
        private string jsonPath = "/Users/harshalb/Projects/JsonFiles/csvjson.json";

        public List<DogViewModel> get()
        {
            var existText = ob.deserealizeRead();

            return existText;
        }

        public DogViewModel get(int id)
        {
            var existText = ob.deserealizeRead();

            var ans = existText?.Find(DogViewModel => DogViewModel.Id == id);
            if (ans == null) return null;

            return ans;
        }

        public void post(DogViewModel value)
        {
            var existText = ob.deserealizeRead();

            existText?.Add(value);

            ob.serializeWrite(existText);
        }

        public void put(DogViewModel value)
        {
            var existText = ob.deserealizeRead();

            if (existText?.Count < 1) return;

            var findDogViewModel = existText?.Find(DogViewModel => DogViewModel.Id == value.Id);
            if (findDogViewModel == null) return;
            existText?.Remove(findDogViewModel);
            existText?.Add(new DogViewModel() { Id = value.Id, Age = value.Age, Name = value.Name });

            ob.serializeWrite(existText);
        }

        public void delete(int id)
        {
            var existText = ob.deserealizeRead();

            if (existText?.Count < 1) return;

            var found = existText?.Find(x => x.Id == id);
            if (found != null) existText?.Remove(found);

            ob.serializeWrite(existText);
        }
    }
}


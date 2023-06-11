using System;
using FirstApp.Models;
using System.Text.Json;


namespace FirstApp
{
	public class CrudOperations
	{
        private string jsonPath = "/Users/harshalb/Projects/JsonFiles/csvjson.json";

        public List<T> get<T>()
		{
            var existText = deserealizeRead<T>();

            return existText;
        }

        public void post<T>(T value)
        {
            var existText = deserealizeRead<T>();

            existText?.Add(value);

            serializeWrite(existText);
        }

        public void put<T>(T value) where T: class, new()
        {
            var existText = deserealizeRead<T>();

            if (existText?.Count < 1) return;

            T ob = new T();
            var cols = ob.GetType().GetProperties();

            //foreach(var col in cols)
            //{
            //    if(col == value.Id)
            //    {

            //    }
            //}

            //var findDog = existText?.Find(dog => dog.Id == T.id);
            //if (findDog == null) return;
            //existText?.Remove(findDog);
            //existText?.Add(new T() { Id = id, Age = value.Age, Name = value.Name });

            serializeWrite(existText);
        }

        public void delete<T>(int id) where T: class, new()
        {
            var existText = deserealizeRead<T>();

            if (existText?.Count < 1) return;

            T ob = new T();
            var cols = ob.GetType().GetProperties();

            //foreach(var dog in existText)
            //{
            //    var value = (int)typeof(T).GetProperty("Id").GetValue(ob);
            //    if(value == id)
            //    {
            //        existText.Remove(new T(){ Id = id});
            //    }
            //}
            
            //var found = existText?.Find(x => x.Id == id);
            //if (found != null) existText?.Remove(found);

            serializeWrite(existText);
        }

        private void serializeWrite<T>(List<T> data)
        {
            var jsonData = JsonSerializer.Serialize(data);
            System.IO.File.WriteAllText(jsonPath, jsonData);
        }

        private List<T> deserealizeRead<T>()
        {
            string existString = System.IO.File.ReadAllText(@jsonPath);
            var existText = JsonSerializer.Deserialize<List<T>>(existString);

            return existText;
        }
    }
}


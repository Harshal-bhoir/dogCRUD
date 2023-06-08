using System;
using FirstApp.Models;
using System.Text.Json;

namespace FirstApp
{
	public class HelperFuncs
	{
		public HelperFuncs()
		{
		}

        private string jsonPath = "/Users/harshalb/Projects/JsonFiles/csvjson.json";

        public void serializeWrite(List<DogViewModel> data)
        {
            var jsonData = JsonSerializer.Serialize(data);
            System.IO.File.WriteAllText(jsonPath, jsonData);
        }

        public List<DogViewModel> deserealizeRead()
        {
            string existString = System.IO.File.ReadAllText(@jsonPath);
            var existText = JsonSerializer.Deserialize<List<DogViewModel>>(existString);

            return existText;
        }
    }
}


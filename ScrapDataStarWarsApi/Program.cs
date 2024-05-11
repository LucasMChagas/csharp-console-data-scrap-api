using ScrapDataStarWarsApi.Models;
using System.Text.Json;

string path =$"{Directory.GetCurrentDirectory()}{Path.DirectorySeparatorChar}StarWarsVehicles.json";
var myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

var client = new HttpClient()
{
    BaseAddress = new Uri("https://swapi.py4e.com/api/"),
};

var list = new List<Vehicle>();

for (int id = 1; id <= 100; id++)
{   
    var response = await client.GetAsync($"vehicles/{id}");
    var item = await response.Content.ReadAsAsync<Vehicle>();
    if(item.name != null)
    {
        item.id = id;        
        list.Add(item);
    }    
}

var json = JsonSerializer.Serialize(list);
File.WriteAllText(path, json);

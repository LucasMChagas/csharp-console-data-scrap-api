using System.Text.Json;

namespace ScrapDataStarWarsApi.Services;

public class RequestToJson
{
    private readonly HttpClient _client;
    public RequestToJson(HttpClient client) => _client = client;

    public async void CreateJson<T>(string endpointToRequest, string path, string fileName)
    {
        var list = new List<T>();

        for (int id = 1; id <= 1; id++)
        {
            var response = await _client.GetAsync($"{endpointToRequest}{id}");
            var item = await response.Content.ReadAsAsync<T>();
            
            list.Add(item);
        }
        var jsonList = JsonSerializer.Serialize(list);
        await File.WriteAllTextAsync($"{path}\\{fileName}", jsonList);        
    }    
}

using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddHttpClient<ChuckNorrisClient>(c => c.BaseAddress = new Uri("https://api.chucknorris.io/"));
var serviceProvider = services.BuildServiceProvider();

var client = serviceProvider.GetService<ChuckNorrisClient>();
var response = await client.GetRandomJokeAsync();

System.Console.WriteLine($"Id: {response.Id}");
System.Console.WriteLine($"Joke: {response.Value}");

public record ChuckNorrisJoke(string Id, string Value, string Url);

public class ChuckNorrisClient
{
    private readonly HttpClient _httpClient;

    public ChuckNorrisClient(HttpClient httpClient) => _httpClient = httpClient;

    public async Task<ChuckNorrisJoke> GetRandomJokeAsync() => await _httpClient.GetFromJsonAsync<ChuckNorrisJoke>("jokes/random");
}
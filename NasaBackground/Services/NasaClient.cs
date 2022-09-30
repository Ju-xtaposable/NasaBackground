
using NasaBackground.Models;
using System.Data;
using System.Net.Http.Json;

namespace NasaBackground.Services;

public class NasaClient
{
    private readonly string baseUrl = "https://api.nasa.gov/planetary/apod";
    private readonly string privateKey = "rKAO1btJxPZXNmn7u9qxZo8VBpZckR11pVfyqhEv";

    public async Task GetImageOfDay()
    {
        HttpClient client = new HttpClient();
        string url = $"{baseUrl}?hd=true&api_key={privateKey}";
        NasaResponse result = await client.GetFromJsonAsync<NasaResponse>(url);

        Console.WriteLine(result.title);
        Console.WriteLine(result.explanation);

        byte[] imageBytes = await client.GetByteArrayAsync(result.hdurl);
        File.WriteAllBytes(@"C:\Users\julie\Pictures\Nasa\Today.jpg", imageBytes);
    }
}
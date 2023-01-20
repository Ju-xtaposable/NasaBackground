
using NasaBackground.Services;

internal class Program
{
    private static async Task Main(string[] args)
    {
        NasaClient nasaClient = new NasaClient();
        await nasaClient.GetImageOfDay();
        Wallpaper.Define();
        Console.WriteLine("Press any key to quit");
        Console.ReadKey();
    }
}
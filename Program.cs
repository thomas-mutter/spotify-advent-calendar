using SpotifyCodeGen;

var links = File.ReadAllLines("links.txt");

Song.BackgroundColor = "71e9fc";
Song.ForegroundColor = BarColor.Black;

using var httpclient = new HttpClient();

if (!Directory.Exists("Results"))
{
    Directory.CreateDirectory("Results");
}

foreach(var song in links.ToSongs())
{
    string imageFile = $"Results/{song.Name}.png";
    Console.WriteLine($"{song.Name}: ");
    if (!File.Exists(imageFile))
    {
        var png = await song.GetImageAsync(httpclient);
        await File.WriteAllBytesAsync($"Results/{song.Name}.png", png);
    }
}

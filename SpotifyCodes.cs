namespace SpotifyCodeGen;

public enum BarColor {
    Black,
    White
}

public class Song {
    public Song(string name, string id)
    {
        Name = name;
        Id = id;
    }

    public string Name { get;}

    public string? Id { get; }

    public static string BackgroundColor { get; set;} = "ffffff";

    public static BarColor ForegroundColor { get; set;} = BarColor.Black;

    public string SpotifyCodeUrl => $"https://scannables.scdn.co/uri/plain/png/{BackgroundColor}/{ForegroundColor.ToString().ToLowerInvariant()}/640/spotify:track:{Id}";

    public async Task<byte[]> GetImageAsync(HttpClient client)
    {
        if (Id == null)
        {
            return Array.Empty<byte>();
        }


        var response = await client.GetAsync(SpotifyCodeUrl);
        return await response.Content.ReadAsByteArrayAsync();
    }
};

public static class SpoifyCodes
{
    public static IEnumerable<Song> ToSongs(this IEnumerable<string> linkFile)
    {
        string? currentTitle = null;

        foreach(string line in linkFile)
        {
            if (string.IsNullOrWhiteSpace(line)) {
                continue;
            }

            if (line.StartsWith("https") && currentTitle != null)
            {
                yield return new Song(currentTitle, GetIdFromUrl(line));
            }

            currentTitle = line.Trim();
        }
    }

    static string GetIdFromUrl(string url)
    {
        // https://open.spotify.com/track/06hsdMbBxWGqBO0TV0Zrkf?si=IN5XRWhIQACfeaVBaxfi7Q
        Uri uri = new(url);
        var pathItems = uri.AbsolutePath.Split('/');
        return pathItems.Last();
    }
}
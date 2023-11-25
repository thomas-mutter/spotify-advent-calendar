# Spotify Advent Calendar
Spotify has the nice feature to create images from its links which may be scanned in the
App. It's simply a link to a song, playlist or other items within Spotify. Its therefore
not possible to give away a song to somebody.

This little piece of code allows to generate a bunch of such little images which then
can be assembled and printed in your preferred layout program. If you decorate it with
numbers from 1..24 you get a nice advent calender.

## Image generation API
To generate a link image, you may do this on https://www.spotifycodes.com/
behind the scenes, a simple URL based API generates the according image which can easlily automated.

```cs
$"https://scannables.scdn.co/uri/plain/png/{BackgroundColor}/{ForegroundColor.ToString().ToLowerInvariant()}/640/spotify:track:{Id}"
```

Parameters:
* Spotify-Id, e.g. 06hsdMbBxWGqBO0TV0Zrkf
* Background-Color: Web color in hex, e.g. 71e9fc"
* Foreground-Color: white or black
* Size: e.g. 640px
* Format: png, svg, jpeg

## Where to get the Id
The Spotify Desktop App allows to copy a link by pressing the ... Button beside the song.
Choose Share -> Copy Link

You will get a link like:
https://open.spotify.com/track/06hsdMbBxWGqBO0TV0Zrkf?si=IN5XRWhIQACfeaVBaxfi7Q

You find the Id as the last path part in the URL.

# Build and Run
This little program is made to be run using dotnet from command line.
It expects all links to be written to a file named `links.txt`. There is a sample available in this repo.

Repeat this for every song:
* First line: Title of the song
* Second line: Spotify URL
* Separator line

```sh
dotnet run
```

The images are written into subfolder `Results`.

Have fun...

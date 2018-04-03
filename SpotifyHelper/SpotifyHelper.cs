using SpotifyAPI;
using SpotifyAPI.Local;
using System;

namespace SpotifyHelper
{
    public class SpotifyHelper
    {
        private readonly SpotifyLocalAPI _spotify;

        public SpotifyHelper()
        {
            var config = new SpotifyLocalAPIConfig
            {
                ProxyConfig = new ProxyConfig()
            };

            _spotify = new SpotifyLocalAPI(config);
            Connect();
        }

        private void Connect()
        {
            if (!SpotifyLocalAPI.IsSpotifyRunning())
            {
                Console.WriteLine(@"Spotify isn't running!");
                return;
            }

            if (!SpotifyLocalAPI.IsSpotifyWebHelperRunning())
            {
                Console.WriteLine(@"SpotifyWebHelper isn't running!");
                return;
            }

            if (_spotify.Connect())
            {
                Console.WriteLine(@"Connection to Spotify successful");
                _spotify.ListenForEvents = true;
            }
            else
            {
                Console.WriteLine(@"Connection to Spotify failed!");
            }
        }

        public async void Play() => await _spotify.Play();

        public async void Pause() => await _spotify.Pause();

        public void Next() => _spotify.Skip();

        public void Previous() => _spotify.Previous();
    }
}

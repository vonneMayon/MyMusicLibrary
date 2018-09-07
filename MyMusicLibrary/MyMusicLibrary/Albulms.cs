using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace MyMusicLibrary
{
    public class Album
    {
        //public string Title { get; set; }

        //public int AlbumNo { get; set; }

        //public string Artist { get; set; }

        //public string Genre { get; set; }

        public string AudioUrl { get; set; }

        public Dictionary<string, string> MyProperty { get; set; }

        public static async Task<ICollection<Album>> GetAlbulmsAsync()
        {
            var albums = new List<Album>();
            StorageFolder myMusicLib = KnownFolders.MusicLibrary;
            var files = await myMusicLib.GetFilesAsync();
            foreach (var file in files)
            {
                var musicProperties = await file.Properties.GetMusicPropertiesAsync();
                
                var albumUrl = musicProperties.Album;
                if (albumUrl == "")
                    continue;
                var album = new Album
                {
                    AudioUrl = albumUrl
                };
                albums.Add(album);
            }
            return albums;
        }

        internal static void WriteAlbums(Album album)
        {
            throw new NotImplementedException();
        }
    }
}

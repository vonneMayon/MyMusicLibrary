using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace MyMusicLibrary
{
    public class Albulms
    {
        public string Title { get; set; }

        public int AlbumNo { get; set; }

        public string Artist { get; set; }

        public string Genre { get; set; }

        public string ImageUrl { get; set; }

        public Dictionary<string, string> MyProperty { get; set; }

        public static Task<ICollection<Albulms>> GetAlbulms()
        {
            //temporary TODO

            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagLib;

namespace AudioPlayer.Core
{
    class Song
    {
        private string FilePath { get; set; }
        private TagLib.File File { get; set; }
        private string SongName { get; set; }
        private string Album { get; set; }
        private string Artist { get; set; }
        private IPicture[] Cover { get; set; }

        public Song(string filePath) 
        {
            FilePath = filePath;

            File = TagLib.File.Create(FilePath);
            if (File.Tag == null)
            {
                SongName = Path.GetFileNameWithoutExtension(FilePath);
                Album = "";
                Artist = "Unkown Artist";
            }
            else
            {
                SongName = File.Tag.Title;
                Artist = File.Tag.FirstAlbumArtist;
                Album = File.Tag.Album;
                Cover = File.Tag.Pictures;
            }
        }
    }
}

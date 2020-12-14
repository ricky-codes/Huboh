using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huboh.FolderWatcher.Interfaces
{
    public interface IMetadataParser
    {
        void CreateFileInstance(string _filepath);
        string GetAlbum();
        string[] GetArtists();
        string[] GetComposers();
        string[] GetGenres();
        string GetLyrics();
        string GetPublisher();
        string GetTitle();
        //_________________________
        int GetTrackNumber();
        int GetSongYear();
        int GetSongBPM();
    }
}

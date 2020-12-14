using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Huboh.Domain.Services;
using Huboh.EntityFramework.Models;
using Huboh.FolderWatcher.Interfaces;

namespace Huboh.FolderWatcher.Activities.Mp3MetadataParser
{
    public class MetadataParser : IMetadataParser
    {

        private TagLib.File _fileInstance;
        public TagLib.File FileInstance
        {
            get { return _fileInstance; }
            set { _fileInstance = value; }
        }


        public void CreateFileInstance(string filepath)
        {
            FileInstance = TagLib.File.Create(filepath);
        }



        public string GetAlbum()
        {
            return FileInstance.Tag.Album;
        }
        public string[] GetArtists()
        {
            return FileInstance.Tag.AlbumArtists;
        }
        public string[] GetComposers()
        {
            return FileInstance.Tag.Composers;
        }
        public string[] GetGenres()
        {
            return FileInstance.Tag.Genres;
        }
        public string GetLyrics()
        {
            return FileInstance.Tag.Lyrics;
        }
        public string GetPublisher()
        {
            return FileInstance.Tag.Publisher;
        }
        public string GetTitle()
        {
            return FileInstance.Tag.Title;
        }


        //___________________________________________

        public int GetTrackNumber()
        {
            return (int)FileInstance.Tag.Track;
        }

        public int GetSongYear()
        {
            return (int)FileInstance.Tag.Year;
        }

        public int GetSongBPM()
        {
            return (int)FileInstance.Tag.BeatsPerMinute;
        }

        //private Songs CreateSongObject(string targetSongPath, string directory)
        //{
        //    return new Songs() {
        //        title = !string.IsNullOrEmpty(TagLib.File.Create(targetSongPath).Tag.Title) ?
        //                TagLib.File.Create(targetSongPath).Tag.Title :
        //                targetSongPath.Substring(directory.Length + 1),
        //        artist = !string.IsNullOrEmpty(TagLib.File.Create(targetSongPath).Tag.FirstPerformer) ?
        //                    TagLib.File.Create(targetSongPath).Tag.FirstPerformer :
        //                    !string.IsNullOrEmpty(TagLib.File.Create(targetSongPath).Tag.FirstAlbumArtist) ?
        //                    TagLib.File.Create(targetSongPath).Tag.FirstAlbumArtist :
        //                    "Desconhecido",
        //        fileIndex = i++,
        //        sourceDirectory = directory,
        //        musicCompletePath = targetSongPath,
        //        albumName = TagLib.File.Create(targetSongPath).Tag.Album,
        //        musicFilename = targetSongPath.Remove(0, directory.Length + 1)
        //    };
        //}

        //public async Task<song> GetSongObjectAsync(string filePath, string directory)
        //{
        //    song songObject = await Task.FromResult<song>(CreateSongObject(filePath, directory));
        //    return songObject;
        //}
    }
}

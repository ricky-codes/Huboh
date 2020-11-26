using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Huboh.Domain.Services;
using Huboh.EntityFramework.Models;

namespace Huboh.FolderWatcher.Activities.Mp3MetadataParser
{
    public class MetadataParser
    {
        int i = 0;
        
        private song CreateSongObject(string targetSongPath, string directory)
        {
            return new song() {
                title = !string.IsNullOrEmpty(TagLib.File.Create(targetSongPath).Tag.Title) ?
                        TagLib.File.Create(targetSongPath).Tag.Title :
                        targetSongPath.Substring(directory.Length + 1),
                artist = !string.IsNullOrEmpty(TagLib.File.Create(targetSongPath).Tag.FirstPerformer) ?
                            TagLib.File.Create(targetSongPath).Tag.FirstPerformer :
                            !string.IsNullOrEmpty(TagLib.File.Create(targetSongPath).Tag.FirstAlbumArtist) ?
                            TagLib.File.Create(targetSongPath).Tag.FirstAlbumArtist :
                            "Desconhecido",
                fileIndex = i++,
                sourceDirectory = directory,
                musicCompletePath = targetSongPath,
                albumName = TagLib.File.Create(targetSongPath).Tag.Album,
                musicFilename = targetSongPath.Remove(0, directory.Length + 1)
            };
        }

        public async Task<song> GetSongObjectAsync(string filePath, string directory)
        {
            song songObject = await Task.FromResult<song>(CreateSongObject(filePath, directory));
            return songObject;
        }
    }
}

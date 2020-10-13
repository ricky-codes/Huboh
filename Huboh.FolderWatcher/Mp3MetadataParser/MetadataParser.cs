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
    public class MetadataParser : IDependencies
    {
        int i = 0;
        public song GetSongObject(string targetSongPath)
        {
            song newSong = new song()
            {
                title = !string.IsNullOrEmpty(TagLib.File.Create(targetSongPath).Tag.Title) ?
                            TagLib.File.Create(targetSongPath).Tag.Title :
                            targetSongPath.Substring(DirectoryPath.Length + 1),
                artist = !string.IsNullOrEmpty(TagLib.File.Create(targetSongPath).Tag.FirstPerformer) ?
                                TagLib.File.Create(targetSongPath).Tag.FirstPerformer :
                                !string.IsNullOrEmpty(TagLib.File.Create(targetSongPath).Tag.FirstAlbumArtist) ?
                                TagLib.File.Create(targetSongPath).Tag.FirstAlbumArtist :
                                "Desconhecido",
                fileIndex = i++,
                sourceDirectory = DirectoryPath,
                musicCompletePath = targetSongPath,
                albumName = TagLib.File.Create(targetSongPath).Tag.Album,
                musicFilename = targetSongPath.Remove(0, DirectoryPath.Length + 1)
            };
            return newSong;
        }
    }
}

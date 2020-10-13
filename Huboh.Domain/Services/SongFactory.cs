using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Huboh.EntityFramework.Models;

namespace Huboh.Domain.Services
{
    public class SongFactory
    {
        private song songToCreate;

        public SongFactory(int _id, int _fileIndex, string _title, string _artist, string _albumName, string _sourceDirectory, string _musicFilename, string _musicCompletePath)
        {
            this.songToCreate = new song()
            {
                id = _id,
                fileIndex = _fileIndex,
                title = _title,
                artist = _artist,
                albumName = _albumName,
                sourceDirectory = _sourceDirectory,
                musicFilename = _musicFilename,
                musicCompletePath = _musicCompletePath
            };

            GetSong();
        }
        
        public song GetSong()
        {
            return this.songToCreate;
        }
    }
}

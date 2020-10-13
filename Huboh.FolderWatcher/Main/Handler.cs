using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Huboh.Domain.Services;
using Huboh.EntityFramework.Models;
using Huboh.FolderWatcher.Activities;
using Huboh.FolderWatcher.Activities.Mp3MetadataParser;

namespace Huboh.FolderWatcher.Main
{
    public class Handler
    {
        private UnitOfWork _unitOfWork;
        private MetadataParser _metadataParser;

        public Handler(UnitOfWork unitOfWork, MetadataParser metadataParser)
        {
            this._unitOfWork = unitOfWork;
            this._metadataParser = metadataParser;
        }


        public void FileChangedHandler(FileSystemEventArgs e)
        {
            if(e.ChangeType == WatcherChangeTypes.Deleted)
            {
                int affectedRecordId = this._unitOfWork.SongRepository.GetAll().First(_song => _song.musicCompletePath == e.FullPath).id;
                this._unitOfWork.SongRepository.Delete(affectedRecordId);
            }
            else if(e.ChangeType == WatcherChangeTypes.Created)
            {
                song newSongToDB = this._metadataParser.GetSongObject(e.FullPath);
                this._unitOfWork.SongRepository.Insert(newSongToDB);
            }
            this._unitOfWork.Save();
        }

        public void FileRenamedHandler(RenamedEventArgs e)
        {
            //TODO Encapsulate inside a try/catch
            //Gets the ID of the renamed file to use in the Update() function
            int affectedRecordId = this._unitOfWork.SongRepository.GetAll().First(_song => _song.musicCompletePath == e.OldFullPath).id; 
            //Gets the object that corresponds to the id
            song affectedRecord = this._unitOfWork.SongRepository.GetByID(affectedRecordId);

            //Updates the path and the file name
            affectedRecord.musicCompletePath = e.FullPath;
            affectedRecord.musicFilename = e.Name;

            //Creates a new object, for the sake of comprehension
            song newDBRecord = affectedRecord;

            this._unitOfWork.SongRepository.Update(affectedRecordId, newDBRecord);
            this._unitOfWork.Save();
        }


    }
}

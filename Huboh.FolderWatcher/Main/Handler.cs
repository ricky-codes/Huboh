using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Timers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Huboh.Domain.Services;
using Huboh.EntityFramework.Models;
using Huboh.FolderWatcher.Interfaces;
using System.Runtime.CompilerServices;

namespace Huboh.FolderWatcher.Main
{
    public class Handler : IHandler
    {
        private UnitOfWork _unitOfWork;
        private IMetadataParser _metadataParser;
        private string _path;
        private NotificationTimer _notificationTimer;

        private List<string> oldFilesToProcess = new List<string>();
        private List<string> newFilesToProcess = new List<string>();

        public Handler(UnitOfWork unitOfWork, IMetadataParser metadataParser , string path)
        {
            this._unitOfWork = unitOfWork;
            this._metadataParser = metadataParser;
            this._notificationTimer = new NotificationTimer();
            this._path = path;
            _notificationTimer.CreateTimer(2000);
            _notificationTimer.TimerElapsed += NotificationTimerElapsed;
        }

        public void FileChangedHandler(object sender, FileSystemEventArgs e)
        {
            _notificationTimer.ResetTimer();

            if (e.ChangeType == WatcherChangeTypes.Deleted)
            {
                oldFilesToProcess.Add(e.FullPath);
            }
            else if(e.ChangeType == WatcherChangeTypes.Created)
            {
                newFilesToProcess.Add(e.FullPath);
            }
        }

        public void FileRenamedHandler(object sender, RenamedEventArgs e)
        {
            try
            {
                int affectedRecordId = this._unitOfWork.FilepathsRepository.GetAll().First(_file => _file.fileFullpath == e.OldFullPath).filePathID;
                FilePaths affectedRecord = this._unitOfWork.FilepathsRepository.GetByID(affectedRecordId);

                affectedRecord.fileFullpath = e.FullPath;
                affectedRecord.fileFilename = e.Name;

                this._unitOfWork.FilepathsRepository.Update(affectedRecordId, affectedRecord);
                this._unitOfWork.Save();
            }
            catch
            {
                Console.WriteLine("[database]: Error; Cannot find the record for {0}", e.OldFullPath);
            }
        }



        private void NotificationTimerElapsed(object sender, ElapsedEventArgs e)
        {
            _notificationTimer.StopTimer();
            Console.WriteLine("[createdFilesToProcess] {0}", newFilesToProcess.Count.ToString());
            Console.WriteLine("[deletedFilesToProcess] {0}", oldFilesToProcess.Count.ToString());

            //Process the lists
            //...
            //...

            if(newFilesToProcess.Count > 0)
            {
                //CreateFileInstance
                //Insert to Filepaths
                //Create Song
                //Insert to Song
                foreach (var item in newFilesToProcess)
                {
                    FilePaths file = new FilePaths 
                    {
                        fileDirectory = _path,
                        fileFullpath = item,
                        fileFilename = item.Substring(0, _path.Length)
                    };

                    _metadataParser.CreateFileInstance(item);

                    Songs song = new Songs
                    {
                        title = _metadataParser.GetTitle(),
                        trackNumber = _metadataParser.GetTrackNumber(),
                        songYear = _metadataParser.GetSongYear(),
                        bpm = _metadataParser.GetSongBPM()
                    };
                    
                    file.Songs.Add(song);


                    _unitOfWork.FilepathsRepository.Insert(file);
                }
                
                
            }
            if(oldFilesToProcess.Count > 0)
            {

            }

            Console.WriteLine("\n[timer] Elapsed");
            newFilesToProcess.Clear();
            oldFilesToProcess.Clear();
        }
    }
}

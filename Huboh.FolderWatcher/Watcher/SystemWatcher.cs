using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Huboh.Domain.Services;
using Huboh.EntityFramework.Models;
using Huboh.FolderWatcher.Activities.Mp3MetadataParser;
using Huboh.FolderWatcher.Interfaces;
using Huboh.FolderWatcher.Main;

namespace Huboh.FolderWatcher.Watcher
{
    public class SystemWatcher : ISystemWatcher
    {
        //Allows the creation of multiple handlers with different functionalities
        private IHandler _handler;

        private FileSystemWatcher _fileSystemWatcher;

        public SystemWatcher(string path, string fileType)
        {
            _fileSystemWatcher = GetFileSystemWatcher(path, fileType);
            _handler = GetIHandler(GetUnitOfWork(), GetMetadataParser(), path);

            _fileSystemWatcher.Path = path;
            _fileSystemWatcher.Filter = fileType;
            _fileSystemWatcher.EnableRaisingEvents = true;
            _fileSystemWatcher.Created += _handler.FileChangedHandler;
            _fileSystemWatcher.Changed += _handler.FileChangedHandler;
            _fileSystemWatcher.Deleted += _handler.FileChangedHandler;
            _fileSystemWatcher.Renamed += _handler.FileRenamedHandler;

            Console.WriteLine("\n[fileSystemWatcher] created\n [watching] {0} \n [type] {1}", path, fileType);

        }

        public FileSystemWatcher GetFileSystemWatcher(string path, string fileType)
        {
            return new FileSystemWatcher(path, fileType);
        }

        public IHandler GetIHandler(UnitOfWork unitOfWork, MetadataParser metadataParser, string path)
        {
            return new Handler(unitOfWork, metadataParser, path);
        }

        public MetadataParser GetMetadataParser()
        {
            Console.WriteLine("[metadataParser] Instanciating...");
            return new MetadataParser();
        }

        public UnitOfWork GetUnitOfWork()
        {
            Console.WriteLine("[unitOfWork] Instanciating...");
            return new UnitOfWork();
        }
    }
}

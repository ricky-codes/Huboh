using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Huboh.Domain.Services;
using Huboh.FolderWatcher.Activities.Mp3MetadataParser;

namespace Huboh.FolderWatcher.Interfaces
{
    public abstract class IDependencies
    {
        private static string _directory;
        private static string _fileType;
        private static UnitOfWork _unitOfWork;
        private static MetadataParser _metadataParser;
        private static FileSystemWatcher _watcher;

        public static string DirectoryPath
        {
            get
            {
                return _directory;
            }
            set
            {
                _directory = value;
            }
        }

        public static string FileType
        {
            get
            {
                return _fileType;
            }
            set
            {
                _fileType = value;
            }
        }

        public static UnitOfWork UnitOfWorkProp
        {
            get
            {
                if (_unitOfWork == null)
                {
                    _unitOfWork = new UnitOfWork();
                }
                return _unitOfWork;
            }
            set
            {
                _unitOfWork = value;
            }
        }

        public static MetadataParser MetadataParserProp 
        {
            get
            {
                if (_metadataParser == null)
                {
                    _metadataParser = new MetadataParser();
                }
                return _metadataParser;
            }
            set
            {
                _metadataParser = value;
            }
        }

        public static FileSystemWatcher WatcherProp
        {
            get
            {
                if (_watcher == null)
                {
                    _watcher = new FileSystemWatcher();
                }
                return _watcher;
            }
            set
            {
                _watcher = value;
            }
        }
    }
}

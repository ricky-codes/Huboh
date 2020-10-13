using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Huboh.Domain.Services;
using Huboh.EntityFramework.Models;
using Huboh.FolderWatcher.Activities.Mp3MetadataParser;
using Huboh.FolderWatcher.Interfaces;
using Huboh.FolderWatcher.Main;

namespace Huboh.FolderWatcher.Watcher
{
    public class SystemWatcher : IDependencies
    {
        private Handler _handler;

        public SystemWatcher(string path, string fileType)
        {

            _handler = new Handler(UnitOfWorkProp, MetadataParserProp);

            DirectoryPath = path;
            FileType = fileType;

            WatcherProp.Path = path;
            WatcherProp.Filter = fileType;
            WatcherProp.EnableRaisingEvents = true;
            WatcherProp.Created += FileChanged;
            WatcherProp.Changed += FileChanged;
            WatcherProp.Deleted += FileChanged;
            WatcherProp.Renamed += FileRenamed;            
        }

        public void FileChanged(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("{0} ----- {1}", e.FullPath, e.ChangeType);
            _handler.FileChangedHandler(e);
        }

        public void FileRenamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine("{0} ----- {1}", e.FullPath, e.ChangeType);
            _handler.FileRenamedHandler(e);
        }
    }
}

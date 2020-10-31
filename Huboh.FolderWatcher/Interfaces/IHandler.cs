using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huboh.FolderWatcher.Interfaces
{
    public interface IHandler
    {
        void FileChangedHandler(object sender, FileSystemEventArgs e);

        void FileRenamedHandler(object sender, RenamedEventArgs e);
    }
}

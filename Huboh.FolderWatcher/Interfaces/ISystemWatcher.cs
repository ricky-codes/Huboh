using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Huboh.Domain.Services;
using Huboh.FolderWatcher.Activities.Mp3MetadataParser;

namespace Huboh.FolderWatcher.Interfaces
{
    public interface ISystemWatcher
    {
        FileSystemWatcher GetFileSystemWatcher(string path, string fileType);
        UnitOfWork GetUnitOfWork();
        MetadataParser GetMetadataParser();
        IHandler GetIHandler(UnitOfWork unitOfWork, MetadataParser metadataParser, string path);
    }
}

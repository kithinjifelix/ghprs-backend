using GHPRS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GHPRS.Core.Interfaces
{
    public interface IFileUploadRepository : IRepository<FileUploads>
    {
        FileUploads GetPendingUploads(string uploadType);
        IEnumerable<Object> GetAllFileUploads(string status);
        void UpdateFile(FileUploads entity);
    }
}

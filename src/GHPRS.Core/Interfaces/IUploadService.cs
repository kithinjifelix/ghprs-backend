using System.Collections.Generic;
using GHPRS.Core.Entities;
using GHPRS.Core.Models;
using System.Threading.Tasks;

namespace GHPRS.Core.Interfaces
{
    public interface IUploadService
    {
        Task<Upload> Upload(UploadModel upload, User user, int organizationId);
        void InsertUploadData(int uploadId);
        List<object> ReadUploadData(int uploadId);
        void OverWriteApproved(int uploadId);
        void Review(Upload upload, Review review);
    }
}

﻿using System.Collections.Generic;
using System.Data;
using GHPRS.Core.Entities;
using GHPRS.Core.Models;
using System.Threading.Tasks;

namespace GHPRS.Core.Interfaces
{
    public interface IUploadService
    {
        Task<Upload> Upload(UploadModel upload, User user, int organizationId);
        Task<FileUploads> UploadMER(MERUploadModel merUploadModel, User user);
        Task<FileUploads> UploadPLHIV(MERUploadModel merUploadModel, User user);
        Task<FileUploads> UploadFacilityData(MERUploadModel merUploadModel, User user);
        void InsertUploadData(int uploadId);
        void InsertMerData();
        void InsertPLHIVData();
        void InsertFacilityData();
        List<object> ReadUploadData(int uploadId);
        void OverWriteApproved(int uploadId);
        void Review(Upload upload, Review review);
        List<string> GetDirectoryFiles();
        Task<DataTable> GetTextFileDataAsync(string fileName, int uploadTypeId);
    }
}

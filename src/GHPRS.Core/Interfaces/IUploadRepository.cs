using System;
using GHPRS.Core.Entities;
using System.Collections.Generic;
using System.Data;

namespace GHPRS.Core.Interfaces
{
    public interface IUploadRepository : IRepository<Upload>
    {
        IEnumerable<Upload> GetFullUploads();
        Upload GetFullUploadById(int id);
        IEnumerable<object> GetList();
        IEnumerable<object> GetListByUser(User user);
        IEnumerable<object> GetListByStatus(UploadStatus status);
        object GetDetailsById(int id);
        void InsertToTable(WorkSheet workSheet, DataTable data, string uploadBatch, Guid uploadBatchGuid);
        void UpdateStatus(int id, UploadStatus status);
        void DeleteFromTable(string tableName, string uploadBatch, Guid uploadBatchGuid);
    }
}

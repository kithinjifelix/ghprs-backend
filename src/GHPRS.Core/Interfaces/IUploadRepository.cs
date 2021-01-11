using GHPRS.Core.Entities;
using System.Collections.Generic;

namespace GHPRS.Core.Interfaces
{
    public interface IUploadRepository : IRepository<Upload>
    {
        IEnumerable<object> GetList();
        object GetDetailsById(int id);
    }
}

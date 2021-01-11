using GHPRS.Core.Entities;
using System.Collections.Generic;

namespace GHPRS.Core.Interfaces
{
    public interface IUploadRepository : IRepository<Upload>
    {
        IEnumerable<object> GetList();
        IEnumerable<object> GetListByUser(User user);
        object GetDetailsById(int id);
    }
}

using GHPRS.Core.Entities;
using GHPRS.Core.Models;
using System.Threading.Tasks;

namespace GHPRS.Core.Interfaces
{
    public interface IUploadService
    {
        Task<Upload> Upload(UploadModel upload, User user);
    }
}

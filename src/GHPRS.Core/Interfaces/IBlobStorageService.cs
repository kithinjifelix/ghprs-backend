using System.Data;
using System.Threading.Tasks;
using GHPRS.Core.Entities;

namespace GHPRS.Core.Interfaces;

public interface IBlobStorageService
{
    Task<DataTable> GetTextAsync(string blobName, int uploadTypeId);
}
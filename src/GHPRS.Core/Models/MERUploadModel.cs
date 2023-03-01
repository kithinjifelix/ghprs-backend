using Microsoft.AspNetCore.Http;

namespace GHPRS.Core.Models
{
    public class MERUploadModel
    {
        public int UploadTypeId { get; set; }
        public IFormFile File { get; set; }
    }
}

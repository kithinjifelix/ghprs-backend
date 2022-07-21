using Microsoft.AspNetCore.Http;

namespace GHPRS.Core.Models
{
    public class MERUploadModel
    {
        public IFormFile File { get; set; }
    }
}

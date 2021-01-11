using Microsoft.AspNetCore.Http;

namespace GHPRS.Core.Models
{
    public class UploadModel
    {
        public int TemplateId { get; set; }
        public IFormFile File { get; set; }
        public string currentUser { get; set; }
    }
}
